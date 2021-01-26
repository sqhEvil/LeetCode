class Solution:
    #正数找最大的3个，负数找最小的2个
    def maximumProduct(self, nums: List[int]) -> int:
        nums.sort()
        return max(nums[-1] * nums[-2] * nums[-3],nums[-1] * nums[1] * nums[2])

 