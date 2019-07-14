
using pprint = pprint.pprint;

using System.Collections.Generic;

using System.Linq;

using System;

public static class sudoku {
    
    public static List<object> b = (from j in Enumerable.Range(0, 9)
        select (from i in Enumerable.Range(0, 9)
            select 0).ToList()).ToList();
    
    public static List<bool> exit = new List<bool> {
        false
    };
    
    public static object isSolved() {
        foreach (var j in Enumerable.Range(0, 9)) {
            foreach (var i in Enumerable.Range(0, 9)) {
                if (b[j][i] == 0) {
                    return false;
                }
            }
        }
        return true;
    }
    
    public static object topLeft(object x) {
        return x - x % 3;
    }
    
    public static object find(object n, object i, object j) {
        i = topLeft(i);
        j = topLeft(j);
        foreach (var l in Enumerable.Range(j, j + 3 - j)) {
            foreach (var k in Enumerable.Range(i, i + 3 - i)) {
                if (b[l][k] == n) {
                    return true;
                }
            }
        }
        return false;
    }
    
    public static object findRowColumn(object n, object k, object l) {
        foreach (var p in Enumerable.Range(0, 9)) {
            if (b[p][k] == n) {
                return true;
            }
        }
        foreach (var p in Enumerable.Range(0, 9)) {
            if (b[l][p] == n) {
                return true;
            }
        }
        return false;
    }
    
    public static object findPlace(object n, object i, object j) {
        var location = 0;
        foreach (var l in Enumerable.Range(j, j + 3 - j)) {
            foreach (var k in Enumerable.Range(i, i + 3 - i)) {
                if (b[l][k] == 0 && !findRowColumn(n, k, l)) {
                    if (location != 0) {
                        return 0;
                    }
                    location = new List<int> {
                        k,
                        l
                    };
                }
            }
        }
        return location;
    }
    
    public static object checkColumn(object n, object l) {
        if (find(n, l[0], l[1])) {
            return true;
        }
        foreach (var j in Enumerable.Range(0, 9)) {
            if (b[j][l[0]] == n) {
                return true;
            }
        }
        return false;
    }
    
    public static object checkRow(object n, object l) {
        if (find(n, l[0], l[1])) {
            return true;
        }
        foreach (var i in Enumerable.Range(0, 9)) {
            if (b[l[0]][i] == n) {
                return true;
            }
        }
        return false;
    }
    
    public static object findLocationRow(object n, object locations) {
        var location = 0;
        foreach (var l in locations) {
            if (!checkColumn(n, l)) {
                if (location == 0) {
                    location = l;
                } else {
                    return 0;
                }
            }
        }
        return location;
    }
    
    public static object findLocationColumn(object n, object locations) {
        var location = 0;
        foreach (var l in locations) {
            if (!checkRow(n, l)) {
                if (location == 0) {
                    location = l;
                } else {
                    return 0;
                }
            }
        }
        return location;
    }
    
    public static object writeNumber(object n, object l) {
        exit[0] = false;
        b[l[1]][l[0]] = n;
        //pprint(n)
        //pprint(l)		
        //pprint(b)
    }
    
    public static object checkBySquare() {
        foreach (var n in Enumerable.Range(1, 10 - 1)) {
            //pprint("n: " + str(n))
            foreach (var j in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(9 - 0) / 3))).Select(_x_1 => 0 + _x_1 * 3)) {
                //pprint("j: " + str(j))
                foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(9 - 0) / 3))).Select(_x_2 => 0 + _x_2 * 3)) {
                    //pprint("i: " + str(i))
                    if (!find(n, i, j)) {
                        //pprint("cant find n")
                        var l = findPlace(n, i, j);
                        //pprint("location: " + str(location))
                        if (l != 0) {
                            writeNumber(n, l);
                        }
                    }
                }
            }
        }
    }
    
    public static object checkByRow() {
        foreach (var j in Enumerable.Range(0, 9)) {
            var numbers = Enumerable.Range(1, 10 - 1);
            var locations = new List<object>();
            foreach (var i in Enumerable.Range(0, 9)) {
                if (b[j][i] == 0) {
                    locations.append(new List<int> {
                        i,
                        j
                    });
                } else {
                    numbers.remove(b[j][i]);
                }
            }
            foreach (var n in numbers) {
                var l = findLocationRow(n, locations);
                if (l != 0) {
                    writeNumber(n, l);
                }
            }
        }
    }
    
    public static object checkByColumn() {
        foreach (var i in Enumerable.Range(0, 9)) {
            var numbers = Enumerable.Range(1, 10 - 1);
            var locations = new List<object>();
            foreach (var j in Enumerable.Range(0, 9)) {
                if (b[j][i] == 0) {
                    locations.append(new List<int> {
                        i,
                        j
                    });
                } else {
                    numbers.remove(b[j][i]);
                }
            }
            foreach (var n in numbers) {
                var l = findLocationColumn(n, locations);
                if (l != 0) {
                    writeNumber(n, l);
                }
            }
        }
    }
    
    public static object hardMetro() {
        b[0][0] = 3;
        b[0][2] = 2;
        b[0][5] = 1;
        b[1][4] = 7;
        b[1][5] = 2;
        b[1][6] = 3;
        b[2][0] = 7;
        b[2][2] = 9;
        b[2][7] = 6;
        b[3][5] = 3;
        b[3][7] = 4;
        b[3][8] = 7;
        b[4][1] = 5;
        b[4][7] = 8;
        b[5][0] = 1;
        b[5][1] = 3;
        b[5][3] = 2;
        b[6][1] = 4;
        b[6][6] = 6;
        b[6][8] = 1;
        b[7][2] = 6;
        b[7][3] = 1;
        b[7][4] = 3;
        b[8][3] = 4;
        b[8][6] = 7;
        b[8][8] = 9;
    }
    
    public static object easyTimes() {
        b[0][2] = 3;
        b[0][5] = 4;
        b[0][6] = 9;
        b[1][1] = 6;
        b[2][3] = 8;
        b[2][5] = 7;
        b[2][8] = 1;
        b[3][0] = 6;
        b[3][2] = 1;
        b[3][6] = 7;
        b[3][8] = 4;
        b[4][2] = 8;
        b[4][3] = 9;
        b[5][0] = 2;
        b[5][1] = 5;
        b[5][2] = 9;
        b[5][4] = 7;
        b[5][6] = 6;
        b[6][1] = 7;
        b[6][2] = 6;
        b[6][3] = 5;
        b[6][4] = 1;
        b[6][5] = 9;
        b[6][8] = 2;
        b[7][2] = 5;
        b[7][3] = 6;
        b[7][7] = 1;
        b[8][3] = 7;
        b[8][5] = 2;
    }
    
    public static object printBoard() {
        var c = (from j in Enumerable.Range(0, 11)
            select (from i in Enumerable.Range(0, 11)
                select "|").ToList()).ToList();
        foreach (var j in Enumerable.Range(0, 11)) {
            if (j % 4 == 3) {
                foreach (var i in Enumerable.Range(0, 11)) {
                    if (i % 4 == 3) {
                        c[j][i] = "+";
                    } else {
                        c[j][i] = "-";
                    }
                }
            }
        }
        foreach (var j in Enumerable.Range(0, 9)) {
            foreach (var i in Enumerable.Range(0, 9)) {
                c[j + (j - j % 3) / 3][i + (i - i % 3) / 3] = b[j][i].ToString();
            }
        }
        pprint("");
        pprint(c);
    }
    
    static sudoku() {
        hardMetro();
        pprint(b);
        exit[0] = true;
        checkBySquare();
        pprint("");
        pprint(b);
    }
}
