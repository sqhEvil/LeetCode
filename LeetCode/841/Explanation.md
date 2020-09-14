//有 N 个房间，开始时你位于 0 号房间。每个房间有不同的号码：0，1，2，...，N-1，并且房间里可能有一些钥匙能使你进入下一个房间。
//在形式上，对于每个房间 i 都有一个钥匙列表 rooms[i]，每个钥匙 rooms[i][j] 由[0, 1，...，N - 1] 中的一个整数表示，其中 N = rooms.length。 钥匙 rooms[i][j] = v 可以打开编号为 v 的房间。
//最初，除 0 号房间外的其余所有房间都被锁住。
//你可以自由地在房间之间来回走动。
//如果能进入每个房间返回 true，否则返回 false。

//示例 1：
//输入: [[1],[2],[3],[]]
//输出: true
//解释:  
//我们从 0 号房间开始，拿到钥匙 1。
//之后我们去 1 号房间，拿到钥匙 2。
//然后我们去 2 号房间，拿到钥匙 3。
//最后我们去了 3 号房间。
//由于我们能够进入每个房间，我们返回 true。
//示例 2：

//输入：[[1,3],[3,0,1],[2],[0]]
//输出：false
//解释：我们不能进入 2 号房间。

解法1（递归）：
思路：
1.使用一个数组存放所有门的打开状态。
2.循环0号门内所有钥匙。
3.递归循环每个钥匙对应的门。
4.递归完成，即所有能够打开的门。
5.循环每个门的状态，返回结果。

//BFS

public bool CanVisitAllRooms1(IList<IList<int>> rooms)
{
    bool result = true;
    if (rooms == null || rooms.Count == 0)
    {
        return true;
    }
    bool[] vs = new bool[rooms.Count];
    vs[0] = true;
    Loop(rooms, rooms[0], vs);
    foreach (var item in vs)
    {
        if (!item)
        {
            result = false;
			break;
        }
    }
    return result;
}

public void Loop(IList<IList<int>> rooms, IList<int> keys, bool[] vs)
{
    for (int i = 0; i < keys.Count; i++)
    {
        if (vs[keys[i]])
        {
            continue;
        }
        vs[keys[i]] = true;
        Loop(rooms, rooms[keys[i]], vs);

    }
}


