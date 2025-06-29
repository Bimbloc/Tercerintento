import json
import os
import matplotlib.pyplot as plt
import numpy as np
import datetime
import logging

##Configurar salida del log 
logging.basicConfig(filename='DataAnalitics.log', level=logging.INFO,filemode="w")

##  Leer todos los archivos
script_path = os.path.dirname(os.path.realpath(__file__))
timestamp = datetime.datetime.now().strftime("%d-%m-%Y_%H-%M-%S")
graphics_path = os.path.join(script_path, "graphics")
os.makedirs(graphics_path, exist_ok=True)
image_path = os.path.join(graphics_path, f"{timestamp}")
print(image_path)
os.makedirs(image_path, exist_ok=True)
folder_path = os.path.dirname(os.path.realpath(__file__))
folder_path += '\\SampleTelemetry'

logging.info(("Carpeta de datos: " + folder_path) )
print("Carpeta de archivos:" +  folder_path)
#Pregunta 1 
#Puntuaciones del libro ordebadas cronologicamente 
orderRatings = np.zeros(6)

#pregunta 2
#lista ordenada cronoligamente de decisiones correctas o erroneas
playerChoices =[] #[Y,N,Y,Y,N]
#jugement 1 == cielo
#sinner 1 == cielo
#jugement != sinner es un acierto
correctGuessFavor = np.zeros(30) ##30 enteros , contamos cuantos acierto s Hay asociados a cada favor
correctGuessSin = np.zeros(30) #30 enteros , contamos cuantos aciertos Hay asociados a cada pecado
wrongGuessFavors = np.zeros(30) #30 enteros , contamos cuantos fallos Hay asociados a cada favor
wrongGuessSins = np.zeros(30) #30 enteros , contamos cuantos fallos Hay asociados a cada pecado

totalRightGueses= 0
totalWrongGuesses=0

totalFavors=0
totalSins= 0

#pregunta 3
dayLoses = np.zeros(6) #Contamos cuantas veces pierde en cada dia 
dayWins = np.zeros(6) #Contamos cuantas veces gana en cada dia
lastDay = 0
currentDay=-1

firstAttemptPoints = np.zeros(6)#puntuacion media de niveveles superados en suprimer intento
firstTryCount=np.zeros(6)
retryAttemptPoints = np.zeros(6)#puntuacion media al reintentar los niveles
retryCount= np.zeros(6)
currentOrder=0

#pregunta 4 
averageChoiceTime = np.zeros(6)#Tiempos medios de decision de cada dia
lastChoiceTime = 0
averageDayTime=[]  
averageDayTime = np.zeros(6) #Tiempos medios de duración de cada dia 
numjugementsperday=np.zeros(6)
#pregunta 5
characterSentences = [np.zeros(6),np.zeros(6),np.zeros(6),np.zeros(6)] #Frases de cada tio de personaje 
characterTypes = np.zeros(4)

#pregunta 6
#Sumamos apariciones en aciertos y en fallos 
totalFavorApearance = np.zeros(30)
totalSinAppearance = np.zeros(30)
    
for file_name in os.listdir(folder_path):
        
        if file_name.endswith('.json'):  #Process only JSON files
            file_path = os.path.join(folder_path, file_name)

            print(f"Procesando archivo: {file_name}")
            logging.info(("procesando archivo "+ file_name))
            # Leer Contenidos de cada archivo
            with open(file_path, 'r') as file:
                data_raw = json.load(file)
                data=[]
                daynum=0
                dayStartTime=0
                sins = []
                favors= []
                characterType =0
                characterSentence =0
                sinner=0
                characterTime=0
                for raw in data_raw:
                    if("DayStart") in raw:
                       
                       daynum=raw["DayStart"]["number"]
                       dayStartTime = raw["DayStart"]["time"] 

                    if("DayEnd") in raw:
                        day={"time":(raw["DayEnd"]["time"]-dayStartTime),"order":raw["DayEnd"]["order"],"number":daynum}
                        data.append({"Day":day})

                    if("NewCharacter")in raw:
                        characterType= raw["NewCharacter"]["type"]
                        characterSentence = raw["NewCharacter"]["sentence"]
                        characterTime = raw["NewCharacter"]["time"]
                        sins=[]
                        favors=[]
                    if("CharacterSinner")in raw:
                        sinner=raw["CharacterSinner"]["sinner"]

                    if("NewSin") in raw:
                        sins.append(raw["NewSin"]["sin"])

                    if("NewFavor") in raw:
                        favors.append(raw["NewFavor"]["favor"])

                    if("CharacterJudgement") in raw:
                        character={"time":(raw["CharacterJudgement"]["time"]-characterTime),
                        "type":characterType,"sentence":characterSentence, "sinner":sinner,"favors":favors,"sins":sins,"judgement":raw["CharacterJudgement"]["judgement"]}
                        data.append({"Character":character})

                    if("Ending")in raw:
                        data.append(raw)
                for obj in data : 
                     if("Day") in obj :
                          currentOrder =obj["Day"]["order"]      
                          orderRatings[obj["Day"]["number"]-1] += obj["Day"]["order"]
                          averageDayTime[obj["Day"]["number"]-1] += obj["Day"]["time"]
                          lastDay = obj["Day"]["number"]-1
                          if(currentDay!=lastDay):#ganamos a la primera 
                               firstTryCount[lastDay]+=1 
                               firstAttemptPoints[lastDay] +=currentOrder
                          if(currentDay==lastDay):#ganamos tras un reintento     
                                 retryAttemptPoints[lastDay] +=currentOrder
                                 retryCount[lastDay]+=1
                          if(currentOrder<0):#hemos perdido
                             currentDay =obj["Day"]["number"]-1
                          else:
                               dayWins[lastDay]+=1 
                     if("Character") in obj :
                          playerChoices.append(obj["Character"]["judgement"])     
                          averageChoiceTime[lastDay]+= (obj["Character"]["time"]-lastChoiceTime)
                          numjugementsperday[lastDay]+=1
                          if(obj["Character"]["sinner"]== obj["Character"]["judgement"]): # acierto
                             totalRightGueses+=1
                             for f in obj["Character"]["favors"]:
                                correctGuessFavor[f]+=1
                                totalFavorApearance[f] +=1
                                totalFavors+=1
                             for p in obj["Character"]["sins"]:
                                correctGuessSin[p]+=1
                                totalSinAppearance[p] +=1
                                totalSins+=1 
                             characterSentences[obj["Character"]["type"]][obj["Character"]["sentence"]] +=1  
                             characterTypes[obj["Character"]["type"]]+=1
                             ##totalSinAppearance[obj["Character"]["sins"]] +=1                                          
                          else:
                               totalWrongGuesses+=1
                               for f in obj["Character"]["favors"]:
                                wrongGuessFavors[f]+=1
                                totalFavorApearance[f] +=1
                                totalFavors+=1
                               for p in obj["Character"]["sins"]:
                                 wrongGuessSins[p]+=1
                                 totalSinAppearance[p] +=1
                                 totalSins+=1
                     if ("Ending" in obj):
                        if (obj["Ending"]["ending"] == 4):
                           dayLoses[lastDay] += 1
                           ##currentDay = -1 
                        ##else:
                          #  if(currentDay == lastDay +1):#supero un nivel tras repetirlo
                           #     retryAttemptPoints[lastDay] +=currentOrder
                           #     retryCount[lastDay]+=1
                           # else:#superas el nivel en tu primer intento
                            #    firstAttemptPoints[lastDay] +=currentDay
                            #    firstTryCount[lastDay]+=1    

#Con los datos de todas las  partida obtenemos las siguientes  graficas

plt.title("Niveles Medios de Orden")
days = list(range(1,len(orderRatings)+1))
plt.xticks(days)
plt.xlabel("Día")
plt.ylabel("Nivel medio de orden")
colors = [{t<=orderRatings.min()*1.15: 'red',orderRatings.min()*1.15 <t<=orderRatings.max()/1.25: 'orange', t>orderRatings.max()/1.25: 'green'}[True] for t in orderRatings ]
#Obtenemos la media de las puntuaciones 
orderCounter= 0 
dayplays=0
for i in range(0,len(orderRatings)):
    dayplays= dayWins[i]+dayLoses[i]
    if(dayplays>0):
        orderRatings[i]= (orderRatings[i]/(dayWins[i]+dayLoses[i]))
    else:
        orderRatings[i]=0    
plt.bar(days,orderRatings,color=colors)
plt.savefig(image_path + "/Pregunta1NivelesOrden.png")


colors = [{t<=dayLoses.min()*1.15: 'green',dayLoses.min()*1.15 <t<=dayLoses.max()/1.25: 'orange', t>dayLoses.max()/1.25: 'red'}[True] for t in dayLoses ]
plt.cla()
plt.title("Derrotas por dia")
plt.xlabel("Día")
plt.ylabel("Número de derrotas")
plt.xticks(np.arange( 1,len(dayLoses)+1))
plt.bar(np.arange(1,len(dayLoses)+1),dayLoses,color=colors)
plt.savefig(image_path + "/Pregunta1DerrotasDia.png")

colors = [{t<=dayWins.min()*1.15: 'red',dayWins.min()*1.15 <t<=dayWins.max()/1.25: 'orange', t>dayWins.max()/1.25: 'green'}[True] for t in dayWins ]
plt.cla()
plt.title("Victorias por dia")
plt.xlabel("Día")
plt.ylabel("Número de Victorias")
plt.xticks(np.arange( 1,len(dayWins)+1))
plt.bar(np.arange(1,len(dayWins)+1),dayWins,color=colors)
plt.savefig(image_path + "/Pregunta1VictoriasDia.png")


numvars = np.arange(0,30)
plt.cla()
plt.title("Tasa de Aciertos Pecados")
plt.xlabel("ID del pecado")
plt.ylabel("Tasa de aciertos(%)")
colors = [{t<=correctGuessSin.min()*1.15: 'red',correctGuessSin.min()*1.15 <t<=correctGuessSin.max()/1.25: 'orange', t>correctGuessSin.max()/1.25: 'green'}[True] for t in correctGuessSin ]
plt.xticks(numvars)
#hay que convertir los datos crudos en tasas
##totalRightGueses = sum(correctGuessSin)
for i in range(0,len(correctGuessSin)):
    correctGSApp=correctGuessSin[i]
    if(correctGSApp>0):
        correctGuessSin[i] = (correctGuessSin[i]/totalRightGueses)*100
    else:
        correctGuessSin[i]=0    

##print(sum(correctGuessSin))    
plt.bar(numvars,correctGuessSin,color=colors)
plt.savefig(image_path + "/Pregunta2PecadosAciertos.png")

plt.cla()
plt.title("Tasa de Fallos Pecados")
plt.xlabel("ID del pecado")
plt.ylabel("Tasa de fallos(%)")
colors = [{t<=wrongGuessSins.min()*1.15: 'green',wrongGuessSins.min()*1.15 <t<=wrongGuessSins.max()/1.25: 'orange', t>wrongGuessSins.max()/1.25: 'red'}[True] for t in wrongGuessSins ]
plt.xticks(numvars)
#hay que convertir los datos crudos en tasas
##totalWrongGueses = sum(wrongGuessSins)
for i in range(0,len(wrongGuessSins)):
   wrongGSApp = wrongGuessSins[i]
   if(wrongGSApp>0): 
        wrongGuessSins[i] = (wrongGuessSins[i]/totalWrongGuesses)*100
   else:
       wrongGuessSins[i]=0
plt.bar(numvars,wrongGuessSins,color=colors)
plt.savefig(image_path + "/Pregunta2PecadosFallos.png")

plt.cla()
colors = [{t<=correctGuessFavor.min()*1.15: 'red',correctGuessFavor.min()*1.15 <t<=correctGuessFavor.max()/1.25: 'orange', t>correctGuessFavor.max()/1.25: 'green'}[True] for t in correctGuessFavor ]

plt.title("Tasa de Aciertos Favores")
plt.xlabel("ID del favor")
plt.ylabel("Tasa de Aciertos (%)")
plt.xticks(numvars)
#hay que convertir los datos crudos en tasas
##totalRightGueses = sum(correctGuessFavor)
for i in range(0,len(correctGuessFavor)):
    correctGFApp=correctGuessFavor[i]
    if(correctGFApp>0):
        correctGuessFavor[i] = (correctGFApp/totalRightGueses)*100
    else:
            correctGuessFavor[i] =0
##print(sum(correctGuessFavor))    
plt.bar(numvars,correctGuessFavor,color=colors)
plt.savefig(image_path + "/Pregunta2FavoresAciertos.png")

colors = [{t<=wrongGuessFavors.min()*1.15: 'green',wrongGuessFavors.min()*1.15 <t<=wrongGuessFavors.max()/1.25: 'orange', t>wrongGuessFavors.max()/1.25: 'red'}[True] for t in wrongGuessFavors ]
plt.cla()
plt.title("Tasa de  Fallos Favores")
plt.xlabel("ID del favor")
plt.ylabel("tasa de fallos(%)")
plt.xticks(numvars)
##totalWrongGueses = sum(wrongGuessSins)
for i in range(0,len(wrongGuessFavors)):
   wrongGFApp = wrongGuessFavors[i]
   if(wrongGFApp>0):
        wrongGuessFavors[i] = (wrongGFApp/totalWrongGuesses)*100
   else:
      wrongGuessFavors[i] =0      
plt.bar(numvars,wrongGuessFavors,color=colors)
plt.savefig(image_path + "/Pregunta2FavoresFallos.png")



plt.cla()
plt.title("Diferencia de Puntuación tras reintentos")
plt.xlabel("Día")
plt.ylabel("Puntuación Media (orden)")
#podria haber 0 attempts en un dia y no deberiamos dividir
for i in range(0,len(firstTryCount)):
    if (firstTryCount[i] !=0):
       firstAttemptPoints[i]=(firstAttemptPoints[i]/firstTryCount[i])
    if (retryCount[i]!=0):
        retryAttemptPoints[i] = (retryAttemptPoints[i]/retryCount[i])   
        
plt.xticks(np.arange( 1,len(dayLoses)+1))
plt.plot(np.arange(1,len(dayLoses)+1),retryAttemptPoints,label="retry")
plt.plot(np.arange(1,len(dayLoses)+1),firstAttemptPoints,label="first Attempt")
plt.legend()
plt.savefig(image_path + "/Pregunta3DiferenciaPuntuacionReintentos.png")

plt.cla()
plt.title("Tiempo medio por dia")
colors = [{t<=averageDayTime.min()*1.15: 'green',averageDayTime.min()*1.15 <t<=averageDayTime.max()/1.25: 'orange', t>averageDayTime.max()/1.25: 'red'}[True] for t in averageDayTime ]
plt.xticks(days)
plt.xlabel("Día")
plt.ylabel("Duración media dia  (ms)")
plt.ticklabel_format(axis='y',style='sci',scilimits=(2,2))
#Calculamos la media
dayplays=0
for i in range(0,len(averageDayTime)):
    dayplays = dayLoses[i] + dayWins[i]
    if(dayplays>0):
        averageDayTime[i]= (averageDayTime[i]/(dayWins[i]+dayLoses[i]))
    else:
        averageDayTime[i]=0    
plt.ylim(averageDayTime.min()/1.5,averageDayTime.max())
plt.bar(days,averageDayTime,color=colors)
plt.savefig(image_path + "/Pregunta4TiempoPorDia.png")



plt.cla()
plt.title("Tiempo medio de Decisión por dia")
colors = [{t<=averageChoiceTime.min()*1.15: 'green',averageChoiceTime.min()*1.15 <t<=averageChoiceTime.max()/1.25: 'orange', t>averageChoiceTime.max()/1.25: 'red'}[True] for t in averageChoiceTime]
plt.xticks(days)
plt.xlabel("Día")
plt.ylabel("Duración media decisión  (ms)")
plt.ticklabel_format(axis='y',style='sci',scilimits=(2,2))
#Calculamos la media
for i in range(0,len(averageChoiceTime)):
    if(numjugementsperday[i]>0):
        averageChoiceTime[i]= (averageChoiceTime[i]/(numjugementsperday[i]))
    else:
        averageChoiceTime[i]=0

plt.ylim(averageChoiceTime.min()/1.5,averageChoiceTime.max())
plt.bar(days,averageChoiceTime,color=colors)
plt.savefig(image_path + "/Pregunta4TiempoPorDecisión.png")

plt.cla()
plt.title("Tasa de aparición Personajes por tipo")
colors = [{t<=characterTypes.min()*1.15: 'red',characterTypes.min()*1.15 <t<=characterTypes.max()/1.25: 'orange', t>characterTypes.max()/1.25: 'green'}[True] for t in characterTypes ]
plt.xlabel("Tipo de personaje")
plt.ylabel("Tasa de personajes generados(%)")
plt.xticks(np.arange(0,len(characterTypes)))
#lo pasamos a tasas 
totalCharacters = sum(characterTypes)
for i in range(0,len(characterTypes)):
    charsTypeApp = characterTypes[i]
    if(charsTypeApp>0):
        characterTypes[i] = (charsTypeApp/totalCharacters)*100
    else:
        characterTypes[i]=0    
plt.bar(np.arange(0,len(characterTypes)),characterTypes,color=colors)
plt.savefig(image_path + "/Pregunta5TiposPersonaje.png")

charCounter = 0
for char in characterSentences:
      plt.cla()
      plt.title("Tasa de apacirion Frases Tipo " + str(charCounter))
      colors = [{t<=char.min()*1.15: 'red',char.min()*1.15 <t<=char.max()/1.25: 'orange', t>char.max()/1.25: 'green'}[True] for t in char ]
      plt.xlabel("ID de la frase")
      plt.ylabel("Tasa de apariciones (%)")
      plt.xticks(np.arange(0,len(char)))
      #lo pasamos a tasas
      
      totalFrases= sum(char)
      for i in range(0,len(char)):
         charApp=char[i]
         if(charApp):
            char[i] = (charApp/totalFrases)*100
         else:
             char[i]=0   
      plt.bar(np.arange(0,len(char)),char,color=colors)
      plt.savefig(image_path + "/Pregunta5FrasesTipo" + str(charCounter) + ".png")
      charCounter+=1

plt.cla()
plt.title("Tasa de Favores totales")
colors = [{t<=totalFavorApearance.min()*1.15: 'red',totalFavorApearance.min()*1.15 <t<=totalFavorApearance.max()/1.25: 'orange', t>totalFavorApearance.max()/1.25: 'green'}[True] for t in totalFavorApearance ]
plt.xlabel("ID del favor")
plt.ylabel("Tasa de apariciones (%)")
plt.xticks(numvars)
for i in range(0,len(totalFavorApearance)):
    totalFApearance = totalFavorApearance[i]
    if(totalFApearance>0):
        totalFavorApearance[i]= (totalFApearance/totalFavors)*100
    else:
        totalFavorApearance[i]=0
#print(sum(totalFavorApearance))
plt.bar(numvars,totalFavorApearance,color=colors)
plt.savefig(image_path + "/Pregunta6AparicionFavores.png")

plt.cla()
plt.title("Tasa de Pecados Totales")
colors = [{t<=totalSinAppearance.min()*1.15: 'red',totalSinAppearance.min()*1.15 <t<=totalSinAppearance.max()/1.25: 'orange', t>totalSinAppearance.max()/1.25: 'green'}[True] for t in totalSinAppearance ]
plt.xlabel("ID del pecado")
plt.ylabel("Tasa de apariciones")
plt.xticks(numvars)
for i in range(0,len(totalSinAppearance)):
    totalSAppearance = totalSinAppearance[i]
    if(totalSAppearance>0):
     totalSinAppearance[i]= ( totalSAppearance/totalSins)*100
    else:
        totalSinAppearance[i]=0
#print(sum(totalSinAppearance))    
plt.bar(numvars,totalSinAppearance,color=colors)
plt.savefig(image_path + "/Pregunta6AparicionPecados.png")

