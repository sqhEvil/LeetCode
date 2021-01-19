def checkStraightLine(self, coordinates: List[List[int]]) -> bool:
    if len(coordinates) <= 2:
        return True
        pass
    a = (coordinates[0][1] - coordinates[1][1]) 
    b = (coordinates[0][0] - coordinates[1][0])
    for x in coordinates[2:]:
       print(abs(b * (x[1] - coordinates[0][1])))
       print(abs(a * (x[0] - coordinates[0][0])))
       if abs(b * (x[1] - coordinates[0][1])) != abs(a * (x[0] - coordinates[0][0])):
           return False
    pass
    return True