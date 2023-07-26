#include <iostream>
#include <Windows.h>
#include <TlHelp32.h>
#include <cmath>
#include "offsets.h"

struct Vector2f {
	public: 

		float X;
		float Y;

		Vector2f(float x, float y) {
			X = x;
			Y = y;
		}
		//Mathematic operations between number and a vector
		Vector2f operator+(const int& second) { return Vector2f(this->X + second, this->Y + second); }
		Vector2f operator-(const int& second) { return Vector2f(this->X - second, this->Y - second); }
		Vector2f operator*(const int& second) { return Vector2f(this->X * second, this->Y * second); }
		Vector2f operator/(const int& second) { return Vector2f(this->X / second, this->Y / second); }

		Vector2f operator+(const float& second) { return Vector2f(this->X + second, this->Y + second); }
		Vector2f operator-(const float& second) { return Vector2f(this->X - second, this->Y - second); }
		Vector2f operator*(const float& second) { return Vector2f(this->X * second, this->Y * second); }
		Vector2f operator/(const float& second) { return Vector2f(this->X / second, this->Y / second); }

		Vector2f operator+(const double& second) { return Vector2f(this->X + second, this->Y + second); }
		Vector2f operator-(const double& second) { return Vector2f(this->X - second, this->Y - second); }
		Vector2f operator*(const double& second) { return Vector2f(this->X * second, this->Y * second); }
		Vector2f operator/(const double& second) { return Vector2f(this->X / second, this->Y / second); }

		//Mathematic operations between two vectors
		Vector2f operator+(const Vector2f& second) { return Vector2f(this->X + second.X, this->Y + second.Y); }
		Vector2f operator-(const Vector2f& second) { return Vector2f(this->X - second.X, this->Y - second.Y); }
		Vector2f operator*(const Vector2f& second) { return Vector2f(this->X * second.X, this->Y * second.Y); }
		Vector2f operator/(const Vector2f& second) { return Vector2f(this->X / second.X, this->Y / second.Y); }

		//Interitance of vectors
		Vector2f operator+=(const Vector2f& second) {  
			this->X += second.X;
			this->Y += second.Y;
			return *this;
		}
		Vector2f operator-=(const Vector2f& second) {
			this->X -= second.X;
			this->Y -= second.Y;
			return *this;
		}
		Vector2f operator*=(const Vector2f& second) {
			this->X *= second.X;
			this->Y *= second.Y;
			return *this;
		}
		Vector2f operator/=(const Vector2f& second) {
			this->X /= second.X;
			this->Y /= second.Y;
			return *this;
		}
};

struct Vector2 {
	public:

		float X;
		float Y;

		Vector2(int x, int y) {
			X = x;
			Y = y;
		}
		//Mathematic operations between number and a vector
		Vector2 operator+(const int& second) { return Vector2(this->X + second, this->Y + second); }
		Vector2 operator-(const int& second) { return Vector2(this->X - second, this->Y - second); }
		Vector2 operator*(const int& second) { return Vector2(this->X * second, this->Y * second); }
		Vector2 operator/(const int& second) { return Vector2(this->X / second, this->Y / second); }

		Vector2 operator+(const float& second) { return Vector2(this->X + second, this->Y + second); }
		Vector2 operator-(const float& second) { return Vector2(this->X - second, this->Y - second); }
		Vector2 operator*(const float& second) { return Vector2(this->X * second, this->Y * second); }
		Vector2 operator/(const float& second) { return Vector2(this->X / second, this->Y / second); }

		Vector2 operator+(const double& second) { return Vector2(this->X + second, this->Y + second); }
		Vector2 operator-(const double& second) { return Vector2(this->X - second, this->Y - second); }
		Vector2 operator*(const double& second) { return Vector2(this->X * second, this->Y * second); }
		Vector2 operator/(const double& second) { return Vector2(this->X / second, this->Y / second); }

		//Mathematic operations between two vectors
		Vector2 operator+(const Vector2& second) { return Vector2(this->X + second.X, this->Y + second.Y); }
		Vector2 operator-(const Vector2& second) { return Vector2(this->X - second.X, this->Y - second.Y); }
		Vector2 operator*(const Vector2& second) { return Vector2(this->X * second.X, this->Y * second.Y); }
		Vector2 operator/(const Vector2& second) { return Vector2(this->X / second.X, this->Y / second.Y); }

		//Interitance of vectors
		Vector2 operator+=(const Vector2& second) {
			this->X += second.X;
			this->Y += second.Y;
			return *this;
		}
		Vector2 operator-=(const Vector2& second) {
			this->X -= second.X;
			this->Y -= second.Y;
			return *this;
		}
		Vector2 operator*=(const Vector2& second) {
			this->X *= second.X;
			this->Y *= second.Y;
			return *this;
		}
		Vector2 operator/=(const Vector2& second) {
			this->X /= second.X;
			this->Y /= second.Y;
			return *this;
		}
};
class Vector3 {
public: 
	float x, y, z;
	Vector3() : x(0.f), y(0.f), z(0.f) {}
	Vector3(float x1, float y1, float z1) : x(x1), y(y1), z(z1) {}
};