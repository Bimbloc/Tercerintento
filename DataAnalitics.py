import json
import os
import pandas as pd
import matplotlib.pyplot as plt


##  Leer todos los archivos
folder_path = './data'

correctChoices = 0
totalChoices =0
    
for file_name in os.listdir(folder_path):
        
        if file_name.endswith('.json'):  # Process only JSON files
            file_path = os.path.join(folder_path, file_name)

            print(f"Processing file: {file_name}")

            # Leer Contenidos de cada archivo
            with open(file_path, 'r') as file:
                data = json.load(file)

                