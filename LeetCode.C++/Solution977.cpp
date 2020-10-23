#include<vector>;
#include <string>
using namespace std;

class Solution {
public:
	vector<int> sortedSquares(vector<int>& A) {
		int e = A.size() - 1, s = 0;
		vector<int> result(e + 1);
		while (s <= e)
		{
			if (A[s] >= 0 || A[s] + A[e] > 0)
			{
				result[e - s] = A[e] * A[e];
				e--;
			}
			else;
			{
				result[e - s] = A[s] * A[s];
				s++;
			}
		}
		return result;
	}

	void reorderList(ListNode* head) {
		vector<ListNode*> v;
		while (head != nullptr)
		{
			v.emplace_back(head);
			head = head->next;

		}
		size_t i = 0;
		size_t j = v.size() - 1;
		while (i < j)
		{
			v[i]->next = nullptr;
			i++;
		}

		while (i < j)
		{
			v[i]->next = v[j];
			i++;
			if (i == j)
			{
				v[i]->next = nullptr;
				break;
			}
			v[j]->next = v[i];
			j--;
		}
	}
	bool isLongPressedName(string name, string typed) {
		char tem;
		size_t i = 0, j = 0;
		while (i < name.size() && j < typed.size())
		{
			if (name[i] == typed[j])
			{
				tem = name[i];
				i++;j++;
			}
			else if (tem == typed[j])
			{
				j++;
			}
			else
			{
				return false;
			}
		}
		return i = name.size();
	}

	bool isPalindrome(ListNode* head)
	{
		ListNode* mid = GetMid(head);
		ListNode* reMid = Revert(mid);
		while (reMid != nullptr)
		{
			if (head->val != reMid->val)
			{
				return false;
			}
		}
		return true;
	}
	ListNode* GetMid(ListNode* head) {
		ListNode* slow = head;
		ListNode* fast = head;
		while (fast != nullptr && fast->next != nullptr)
		{
			slow = slow->next;
			fast = fast->next->next;
		}
		return slow;
	}
	ListNode* Revert(ListNode* mid) {
		if (mid == nullptr) return mid;
		ListNode* result = mid;
		ListNode* next = mid->next;
		result->next = nullptr;
		while (next != nullptr)
		{
			ListNode* tem = result;
			result = next;
			next = next->next;
			result->next = tem;
		}
		return result;
	}
};

struct ListNode {
	int val;
	ListNode* next;
	ListNode() : val(0), next(nullptr) {}
	ListNode(int x) : val(x), next(nullptr) {}
	ListNode(int x, ListNode* next) : val(x), next(next) {}

};