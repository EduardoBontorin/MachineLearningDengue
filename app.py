import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.tree import DecisionTreeRegressor, plot_tree
from matplotlib.backends.backend_pdf import PdfPages


dataTreino = pd.read_csv('dados.csv')
dataTeste = pd.read_csv('dadosCWB.csv')
treino_x = dataTreino[['TempMin', 'TempMax', 'Chuva']]
treino_y = dataTreino['Casos']

teste_x = dataTeste[['TempMin', 'TempMax', 'Chuva']]
teste_y = dataTeste['Casos']

SEED = 5
np.random.seed(SEED)


modelo = DecisionTreeRegressor(max_depth=5, random_state=SEED)

print("Treino x e Y", treino_x.head(), treino_y.head())
modelo.fit(treino_x, treino_y)


previsoes = modelo.predict(teste_x)


previsoes = np.maximum(previsoes, 0)

# Plotar somente casos previstos
plt.figure(figsize=(10, 5))
# plt.plot(teste_y.values, label='Casos Reais')
plt.plot(previsoes, label='Casos Previstos')
plt.xlabel('Amostras')
plt.ylabel('Número de Casos')
plt.legend()
plt.show()

# Plotar somente casos reais
plt.figure(figsize=(10, 5))
plt.plot(teste_y.values, label='Casos Reais')
# plt.plot(previsoes, label='Casos Previstos')
plt.xlabel('Amostras')
plt.ylabel('Número de Casos')
plt.legend()
plt.show()


# Plotar casos reais e previstos
plt.figure(figsize=(10, 5))
plt.plot(teste_y.values, label='Casos Reais')
plt.plot(previsoes, label='Casos Previstos')
plt.xlabel('Amostras')
plt.ylabel('Número de Casos')
plt.legend()
plt.show()

# arvore pdf
with PdfPages('arvore_decisao.pdf') as pdf:
    plt.figure(figsize=(20, 10))
    plot_tree(modelo, feature_names=[
              'TempMin', 'TempMax', 'Chuva'], filled=True)
    pdf.savefig()
    plt.close()
