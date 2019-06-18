from pprint import pprint

added = 0
b = [[0 for i in range(9)] for j in range(9)]

def isSolved():
	for j in range(9):
		for i in range(9):
			if b[j][i] == 0:
				return False
	return True

def topLeft(x):
	return x - (x % 3)

def find(n, i, j):
	i = topLeft(i)
	j = topLeft(j)
	for l in range(j, j+3):
		for k in range(i, i+3):
			if b[l][k] == n:
				return True
	return False
	
def findRowColumn(n, k, l):
	for p in range(9):
		if b[p][k] == n:
			return True
	for p in range(9):
		if b[l][p] == n:
			return True
	return False
	
def findPlace(n, i, j):
	location = 0
	for l in range(j, j+3):
		for k in range(i, i+3):
			if b[l][k] == 0 and not findRowColumn(n, k, l):
				if location != 0:
					return 0
				location = [k, l]
	return location
	
def checkColumn(n,l):
	if find(n,l[0],l[1]):
		return True
	for j in range(9):
		if b[j][l[0]] == n:
			return True
	return False
	
def checkRow(n,l):
	if find(n,l[0],l[1]):
		return True
	for i in range(9):
		if b[l[0]][i] == n:
			return True
	return False

def findLocationRow(n,locations):
	location = 0
	for l in locations:
		if not checkColumn(n,l):
			if location == 0:
				location = l
			else:
				return 0
	return location

def findLocationColumn(n,locations):
	location = 0
	for l in locations:
		if not checkRow(n,l):
			if location == 0:
				location = l
			else:
				return 0
	return location

def writeNumber(n,l):
	b[l[1]][l[0]] = n
	pprint(n)
	pprint(l)		
	pprint(b)
	added = added + 1
	
def checkBySquare():
	for n in range(1,10):
		#pprint("n: " + str(n))
		for j in range(0,9,3):
			#pprint("j: " + str(j))
			for i in range(0,9,3):
				#pprint("i: " + str(i))
				if not find(n,i,j):
					#pprint("cant find n")
					l = findPlace(n,i,j)
					#pprint("location: " + str(location))
					if l != 0:
						writeNumber(n,l)
						exit = False

def checkByRow():
	for j in range(9):
		numbers = range(1,10)
		locations = []
		for i in range(9):
			if b[j][i] == 0:
				locations.append([i,j])
			else:
				numbers.remove(b[j][i])
		for n in numbers:
			l = findLocationRow(n, locations)
			if l != 0:
				writeNumber(n,l)
				exit = False
				
def checkByColumn():
	for i in range(9):
		numbers = range(1,10)
		locations = []
		for j in range(9):
			if b[j][i] == 0:
				locations.append([i,j])
			else:
				numbers.remove(b[j][i])
		for n in numbers:
			l = findLocationColumn(n,locations)
			if l != 0:
				writeNumber(n,l)
				exit = False

def hardMetro():
	b[0][0] = 3
	b[0][2] = 2
	b[0][5] = 1
	b[1][4] = 7
	b[1][5] = 2
	b[1][6] = 3
	b[2][0] = 7
	b[2][2] = 9
	b[2][7] = 6
	b[3][5] = 3
	b[3][7] = 4
	b[3][8] = 7
	b[4][1] = 5
	b[4][7] = 8
	b[5][0] = 1
	b[5][1] = 3
	b[5][3] = 2
	b[6][1] = 4
	b[6][6] = 6
	b[6][8] = 1
	b[7][2] = 6
	b[7][3] = 1
	b[7][4] = 3
	b[8][3] = 4
	b[8][6] = 7
	b[8][8] = 9
	
def easyTimes():
	b[0][2] = 3
	b[0][5] = 4
	b[0][6] = 9
	b[1][1] = 6
	b[2][3] = 8
	b[2][5] = 7
	b[2][8] = 1
	b[3][0] = 6
	b[3][2] = 1
	b[3][6] = 7
	b[3][8] = 4
	b[4][2] = 8
	b[4][3] = 9
	b[5][0] = 2
	b[5][1] = 5
	b[5][2] = 9
	b[5][4] = 7
	b[5][6] = 6
	b[6][1] = 7
	b[6][2] = 6
	b[6][3] = 5
	b[6][4] = 1
	b[6][5] = 9
	b[6][8] = 2
	b[7][2] = 5
	b[7][3] = 6
	b[7][7] = 1
	b[8][3] = 7
	b[8][5] = 2

easyTimes()
pprint(b)
exit = False
#while not isSolved():
#if True:
while not exit:
	exit = True
	checkBySquare()
	checkByRow()
	checkByColumn()
pprint(added)
