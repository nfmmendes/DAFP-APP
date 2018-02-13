from math import sin, cos, sqrt, atan2, radians



class LatLong:
    nome = ""
    lat = 0
    long = 0
	
    def __init__(self,n, lt,lg):
        self.nome = n 
        self.lat = lt 
        self.long = lg
    

		

list = []
with open("long.txt", "r") as ins:
    for line in ins:
        split = line.split("\t")
        list.append(LatLong(split[0],split[1],split[2]))
        
num = len(list)


R = 6373.0
def getDistance(lat1, lon1, lat2, lon2):
    dlon = radians(float(lon2)) - radians(float(lon1))
    dlat = radians(float(lat2)) - radians(float(lat1))

    a = sin(dlat / 2)**2 + cos(radians(float(lat1))) * cos(radians(float(lat2))) * sin(dlon / 2)**2
    c = 2 * atan2(sqrt(a), sqrt(1 - a))
    
    return R*c



for i in range(1,num):
    for j in range(1,num):
        if(j == i):
            continue;
        print("{0}\t{1}\t{2}".format(list[i].nome,list[j].nome,getDistance(list[i].lat,list[i].long,list[j].lat,list[j].long)))
    

    