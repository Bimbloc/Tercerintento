import json
import os
import matplotlib.pyplot as plt
import numpy as np

##  Leer todos los archivos
folder_path = os.path.dirname(os.path.realpath(__file__))

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

#pregunta 3
dayLoses = np.zeros(6) #Contamos cuantas veces pierde en cada dia 
lastDay = 0

#pregunta 4 
averageChoiceTime=[] #Tiempos medios de decision de cada dia ordenados cronologicamente
averageChoiceTime = np.zeros(6)

#pregunta 5
characterSentences = [np.zeros(6),np.zeros(6),np.zeros(6),np.zeros(6)] #Frases de cada tio de personaje 
characterTypes = np.zeros(4)

#pregunta 6
#Sumamos apariciones en aciertos y en fallos 
totalFavorApearance = np.zeros(30)
totalSinAppearance = np.zeros(30)
    
for file_name in os.listdir(folder_path + '/TelemetryData'):
        
        if file_name.endswith('.json'):  #Process only JSON files
            file_path = os.path.join(folder_path + '/TelemetryData', file_name)

            print(f"Processing file: {file_name}")

            # Leer Contenidos de cada archivo
            with open(file_path, 'r') as file:
                data = json.load(file)
                
                for obj in data : 
                     if("day") in obj :
                          orderRatings[obj["day"]["number"]-1] += obj["day"]["order"]
                          averageChoiceTime[obj["day"]["number"]-1] += obj["day"]["time"]
                          lastDay = obj["day"]["number"]-1
                     if("character") in obj :
                          playerChoices.append(obj["character"]["judgement"])     
                          if(obj["character"]["sinner"]== obj["character"]["judgement"]): # acierto
                             for f in obj["character"]["favores"]:
                                correctGuessFavor[f]+=1
                                totalFavorApearance[f] +=1
                             for p in obj["character"]["pecados"]:
                                correctGuessSin[p]+=1
                                totalSinAppearance[p] +=1 
                             characterSentences[obj["character"]["type"]][obj["character"]["sentence"]] +=1  
                             characterTypes[obj["character"]["type"]]+=1
                             totalSinAppearance[obj["character"]["pecados"]] +=1                                          
                          else:
                               for f in obj["character"]["favores"]:
                                wrongGuessFavors[f]+=1
                                totalFavorApearance[f] +=1
                               for p in obj["character"]["pecados"]:
                                 wrongGuessSins[p]+=1
                                 totalSinAppearance[p] +=1
                     if ("final" in obj):
                        if (obj["final"]["final"] == 4):
                           dayLoses[lastDay] += 1

#Con los datos de cada partida obtenemos graficas
plt.title("Niveles de Orden")
days = list(range(1,len(orderRatings)+1))
plt.xticks(days)
plt.xlabel("Día")
plt.ylabel("Nivel de orden")
colors = [{t<=orderRatings.min()*1.15: 'red',orderRatings.min()*1.15 <t<=orderRatings.max()/1.25: 'orange', t>orderRatings.max()/1.25: 'green'}[True] for t in orderRatings ]
plt.bar(days,orderRatings,color=colors)
plt.savefig(folder_path + "/Pregunta1NivelesOrden.png")

numvars = np.arange(0,30)
plt.title("Pecados Aciertos")
plt.xlabel("ID del pecado")
plt.ylabel("Número de aciertos")
colors = [{t<=correctGuessSin.min()*1.15: 'red',correctGuessSin.min()*1.15 <t<=correctGuessSin.max()/1.25: 'orange', t>correctGuessSin.max()/1.25: 'green'}[True] for t in correctGuessSin ]
plt.xticks(numvars)
plt.bar(numvars,correctGuessSin,color=colors)
plt.savefig(folder_path + "/Pregunta2PecadosAciertos.png")

plt.title("Pecados Fallos")
plt.xlabel("ID del pecado")
plt.ylabel("Número de fallos")
colors = [{t<=wrongGuessSins.min()*1.15: 'red',wrongGuessSins.min()*1.15 <t<=wrongGuessSins.max()/1.25: 'orange', t>wrongGuessSins.max()/1.25: 'green'}[True] for t in wrongGuessSins ]
plt.xticks(numvars)
plt.bar(numvars,wrongGuessSins,color=colors)
plt.savefig(folder_path + "/Pregunta2PecadosFallos.png")

colors = [{t<=correctGuessFavor.min()*1.15: 'red',correctGuessFavor.min()*1.15 <t<=correctGuessFavor.max()/1.25: 'orange', t>correctGuessFavor.max()/1.25: 'green'}[True] for t in correctGuessFavor ]
plt.title("Favores Aciertos")
plt.xlabel("ID del favor")
plt.ylabel("Número de Aciertos")
plt.xticks(numvars)
plt.bar(numvars,correctGuessFavor,color=colors)
plt.savefig(folder_path + "/Pregunta2FavoresAciertos.png")

colors = [{t<=wrongGuessFavors.min()*1.15: 'red',wrongGuessFavors.min()*1.15 <t<=wrongGuessFavors.max()/1.25: 'orange', t>wrongGuessFavors.max()/1.25: 'green'}[True] for t in wrongGuessFavors ]
plt.title("Favores Fallos")
plt.xlabel("ID del favor")
plt.ylabel("Número de fallos")
plt.xticks(numvars)
plt.bar(numvars,wrongGuessFavors,color=colors)
plt.savefig(folder_path + "/Pregunta2FavoresFallos.png")

colors = [{t<=dayLoses.min()*1.15: 'red',dayLoses.min()*1.15 <t<=dayLoses.max()/1.25: 'orange', t>dayLoses.max()/1.25: 'green'}[True] for t in dayLoses ]
plt.title("Derrotas por dia")
plt.xlabel("Día")
plt.ylabel("Número de derrotas")
plt.xticks(np.arange( 1,len(dayLoses)+1))
plt.bar(np.arange(1,len(dayLoses)+1),dayLoses,color=colors)
plt.savefig(folder_path + "/Pregunta3Derrotas.png")

plt.title("Tiempo por dia")
colors = [{t<=averageChoiceTime.min()*1.15: 'red',averageChoiceTime.min()*1.15 <t<=averageChoiceTime.max()/1.25: 'orange', t>averageChoiceTime.max()/1.25: 'green'}[True] for t in averageChoiceTime ]
plt.xticks(days)
plt.xlabel("Día")
plt.ylabel("Tiempo medio de decisión (ms)")
plt.ylim(averageChoiceTime.min()/1.5,averageChoiceTime.max())
plt.ticklabel_format(axis='y',style='sci',scilimits=(2,2))
plt.bar(days,averageChoiceTime,color=colors)
plt.savefig(folder_path + "/Pregunta4TiempoPorDia.png")

plt.title("Personajes por tipo")
colors = [{t<=characterTypes.min()*1.15: 'red',characterTypes.min()*1.15 <t<=characterTypes.max()/1.25: 'orange', t>characterTypes.max()/1.25: 'green'}[True] for t in characterTypes ]
plt.xlabel("Tipo de personaje")
plt.ylabel("Número de personajes generados")
plt.xticks(np.arange(0,len(characterTypes)))
plt.bar(np.arange(0,len(characterTypes)),characterTypes,color=colors)
plt.savefig(folder_path + "/Pregunta5TiposPersonaje.png")

charCounter = 0
for char in characterSentences:
      plt.title("Frases Tipo " + str(charCounter))
      colors = [{t<=char.min()*1.15: 'red',char.min()*1.15 <t<=char.max()/1.25: 'orange', t>char.max()/1.25: 'green'}[True] for t in char ]
      plt.xlabel("ID de la frase")
      plt.ylabel("Número de apariciones")
      plt.xticks(np.arange(0,len(char)))
      plt.bar(np.arange(0,len(char)),char,color=colors)
      plt.savefig(folder_path + "/Pregunta5FrasesTipo" + str(charCounter) + ".png")
      charCounter+=1

plt.title("Favores totales")
colors = [{t<=totalFavorApearance.min()*1.15: 'red',totalFavorApearance.min()*1.15 <t<=totalFavorApearance.max()/1.25: 'orange', t>totalFavorApearance.max()/1.25: 'green'}[True] for t in totalFavorApearance ]
plt.xlabel("ID del favor")
plt.ylabel("Número de apariciones")
plt.xticks(numvars)
plt.bar(numvars,totalFavorApearance,color=colors)
plt.savefig(folder_path + "/Pregunta6AparicionFavores.png")

plt.title("Pecados Total")
colors = [{t<=totalSinAppearance.min()*1.15: 'red',totalSinAppearance.min()*1.15 <t<=totalSinAppearance.max()/1.25: 'orange', t>totalSinAppearance.max()/1.25: 'green'}[True] for t in totalSinAppearance ]
plt.xlabel("ID del pecado")
plt.ylabel("Número de apariciones")
plt.xticks(numvars)
plt.bar(numvars,totalSinAppearance,color=colors)
plt.savefig(folder_path + "/Pregunta6AparicionPecados.png")
                  
                