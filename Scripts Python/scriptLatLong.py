with open("long.txt", "r") as ins:
    for line in ins:
        split = line.split("\t")
        
        if float(split[1])%1 >= 0.01:
            print("{0}º{1}'{2}'' {3}".format(split[0],int(float(split[1])),round((float(split[1])-int(float(split[1])))*60) ,split[2].split("\n")[0]))
        else:
            print("{0}º{1}' {2}".format(split[0],int(float(split[1])) ,split[2].split("\n")[0]))
    

