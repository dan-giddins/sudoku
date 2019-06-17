from pprint import pprint

def isSolved():
	for j in range(9):
		for i in range(9):
			if b[j][i] == 0:
				return False
	return True

def find(n, i, j):
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
	for j in range(9):
		if b[j][l[0]] == n:
			return true
	return false

def findLocationRow(n):
	location = 0
	for l in locations:
		if not checkColumn(n,l):
			if location == 0
				location = l
			else:
				return 0
	return location

def writeNumber(n,l):
	b[l[1]][l[0]] = n
	pprint(n)
	pprint(l)		
	pprint(b)

b = [[0 for i in range(9)] for j in range(9)]
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
pprint(b)
exit = False
#while not isSolved():
#if True:
while not exit:
	exit = True
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
	for j in range(9):
		numbers = range(1,10)
		locations = []
		for i in range(9):
			if b[j][i] == 0:
				locations.add([i,j])
			else:
				numbers.remove(b[j][i])
		for n in numbers:
			l = findLocationRow(n)
			if l != 0:
				writeNumber(n,l)
				exit = False
				
				
			
					