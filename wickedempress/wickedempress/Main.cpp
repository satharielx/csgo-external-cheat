#include <iostream>
#include <Windows.h>
#include <TlHelp32.h>
#include <cmath>
#include "offsets.h"
#include "types.h"

using namespace std;

const int ScreenWidth = GetSystemMetrics(SM_CXSCREEN);
const int ScreenHeight = GetSystemMetrics(SM_CYSCREEN);

struct Crosshair {
public:
	int x = ScreenWidth / 2;
	int y = ScreenHeight / 2;
	Vector2 getCoords() {
		return Vector2(x, y);
	}
} hair;

struct view_matrix_t {
	float matrix[16];
} vm;

struct Vector3 WorldToScreen(const struct Vector3 pos, struct view_matrix_t matrix) {
	struct Vector3 out;
	float _x = matrix.matrix[0] * pos.x + matrix.matrix[1] * pos.y + matrix.matrix[2] * pos.z + matrix.matrix[3];
	float _y = matrix.matrix[4] * pos.x + matrix.matrix[5] * pos.y + matrix.matrix[6] * pos.z + matrix.matrix[7];
	out.z = matrix.matrix[12] * pos.x + matrix.matrix[13] * pos.y + matrix.matrix[14] * pos.z + matrix.matrix[15];

	_x *= 1.f / out.z;
	_y *= 1.f / out.z;

	out.x = ScreenWidth * .5f;
	out.y = ScreenHeight * .5f;

	out.x += 0.5f * _x * ScreenWidth + 0.5f;
	out.y -= 0.5f * _y * ScreenHeight + 0.5f;

	return out;
}
HWND Window;
DWORD ProcessID;
HANDLE ProcessHandle;
uintptr_t ModuleBase;
HDC Hdc;
int closestEntity;
const int MAX_PLAYERS = 32;

uintptr_t GetModuleBase(const char* modName) {
	HANDLE hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, ProcessID);
	if (hSnap != INVALID_HANDLE_VALUE) {
		MODULEENTRY32 modEntry;
		modEntry.dwSize = sizeof(modEntry);
		if (Module32First(hSnap, &modEntry)) {
			do {
				if (!strcmp(modEntry.szModule, modName)) {
					CloseHandle(hSnap);
					return (uintptr_t)modEntry.modBaseAddr;
				}
			} while (Module32Next(hSnap, &modEntry));
		}
	}
}

//templates
template<typename T> T ReadValue(SIZE_T address) {
	T buffer;
	ReadProcessMemory(ProcessHandle, (LPCVOID)address, &buffer, sizeof(T), NULL);
	return buffer;
}

int GetPlayerTeam(uintptr_t player) {
	return ReadValue<int>(player + m_iTeamNum);
}

uintptr_t GetLocalPlayer() {
	return ReadValue<uintptr_t>(ModuleBase + dwLocalPlayer);
}

uintptr_t GetPlayer(int index) {
	return ReadValue<uintptr_t>(ModuleBase + dwEntityList + index * 0x10);
}

int GetPlayerHealth(uintptr_t Player) {
	return ReadValue<int>(Player + m_iHealth);
}

Vector3 PlayerCoords(uintptr_t Player) {
	return ReadValue<Vector3>(Player + m_vecOrigin);
}

bool IsPlayerValidEntity(uintptr_t Player) {
	return ReadValue<int>(Player + m_bDormant);
}

Vector3 GetHeadCoords(uintptr_t Player) { 
	struct boneMatrix_t {
		byte pad3[12];
		float x;
		byte pad1[12];
		float y;
		byte pad2[12];
		float z;
	};
	uintptr_t boneBase = ReadValue<uintptr_t>(Player + m_dwBoneMatrix);
	boneMatrix_t b = ReadValue<boneMatrix_t>(boneBase + 0x30 + (sizeof(b) * 8));
	return Vector3(b.x, b.y, b.z);
}

float custompow(float x, int step) {
	if (step == 0) return 1;
	if (step == 1) return x;
	if (step % 2 == 0) return custompow(x * x, step / 2);
	else return x * custompow(x * x, step / 2);
}

float Pythag(int x, int y, int x1, int x2) {
	return sqrt(custompow(x1 - x, 2) + custompow(x2 - y, 2));
}

void DrawLine(float StartX, float StartY, float EndX, float EndY) { //This function is optional for debugging.
	int a, b = 0;
	HPEN hOPen;
	HPEN hNPen = CreatePen(PS_SOLID, 2, 0x0000FF /*red*/);
	hOPen = (HPEN)SelectObject(Hdc, hNPen);
	MoveToEx(Hdc, StartX, StartY, NULL); //start of line
	a = LineTo(Hdc, EndX, EndY); //end of line
	DeleteObject(SelectObject(Hdc, hOPen));
}

int FindClosestEntity() {
	float Finish;
	int ClosestEntity = 1;
	Vector3 Calc = { 0, 0, 0 };
	float Closest = FLT_MAX;
	int localTeam = GetPlayerTeam(GetLocalPlayer());
	for (int i = 1; i < 64; i++) { //Loops through all the entitys in the index 1-64.
		DWORD Entity = GetPlayer(i);
		int EnmTeam = GetPlayerTeam(Entity); if (EnmTeam == localTeam) continue;
		int EnmHealth = GetPlayerHealth(Entity); if (EnmHealth < 1 || EnmHealth > 100) continue;
		int Dormant = IsPlayerValidEntity(Entity); if (Dormant) continue;
		Vector3 headBone = WorldToScreen(GetHeadCoords(Entity), vm);
		Finish = Pythag(headBone.x, headBone.y, hair.x, hair.y);
		if (Finish < Closest) {
			Closest = Finish;
			ClosestEntity = i;
		}
	}

	return ClosestEntity;
}
 
void ClosestThread() {
	while (true) {
		closestEntity = FindClosestEntity();
		cout << closestEntity << endl;
		cout << "Crosshair pos: " << hair.x << "; " << hair.y << endl;
	}
}

int main() {
	Window = FindWindowA(NULL, "Counter Strike: Global Offensive");
	GetWindowThreadProcessId(Window, &ProcessID);
	ModuleBase = GetModuleBase("client.dll");
	ProcessHandle = OpenProcess(PROCESS_ALL_ACCESS, NULL, ProcessID);
	Hdc = GetDC(Window); 
	CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)ClosestThread, NULL, NULL, NULL);
	while (!GetAsyncKeyState(VK_NUMPAD6)) {
		vm = ReadValue<view_matrix_t>(ModuleBase + dwViewMatrix);
		Vector3 closestHead = WorldToScreen(GetHeadCoords(GetPlayer(closestEntity)), vm);
		printf("Closest head: %.f, %.f, %.f", closestHead.x, closestHead.y, closestHead.z);
		DrawLine(hair.x, hair.y, closestHead.x, closestHead.y);
		if (GetAsyncKeyState(VK_LBUTTON) && closestHead.z >= 0.001f) {
			SetCursorPos(closestHead.x, closestHead.y);
			Sleep(50);
		}
	}
}



