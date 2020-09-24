// LeetCode.C++.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
using namespace std;

//祖先类
class R
{
private:
	int r;
public:
	R(int x = 0) :r(x) {};
	void f()
	{
		cout << "r" << r << endl;
	}
	void print()
	{
		cout << "print R:" << r << endl;
	}
};

//父类A
class A :public R
{
private:
	int a;
public:
	A(int x) :a(x) {};
	void f()
	{
		cout << "a=" << a << endl;
		//R::f();//调用的父类的f函数
	}
};

//父类B
class B :public R
{
private:
	int b;
public:
	B(int x) :b(x) {};
	void f()
	{
		cout << "b=" << b << endl;
		//R::f();//调用的父类的f函数
	}
};

//子类C
class C :public A, public B
{
private:
	int c;
public:
	C(int x = 1) :c(x), A(x), B(x) {};
	void f()
	{
		cout << "c" << c << endl;
		//A::f();
		//B::f();
	}
};


int main()
{
	C cc(1);
	cc.f();
	cout << "Hello World!\n";
	return 0;
}
// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
