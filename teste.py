import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.tree import DecisionTreeRegressor
from sklearn.metrics import mean_squared_error
from sklearn.model_selection import GridSearchCV, train_test_split

# Carregar os dados
# Certifique-se de que o caminho está correto
dataTreino = pd.read_csv('dados.csv')
dataTeste = pd.read_csv('dadosCWB.csv')
treino_x = dataTreino[['TempMin', 'TempMax', 'Chuva']]
treino_y = dataTreino['Casos']

teste_x = dataTeste[['TempMin', 'TempMax', 'Chuva']]
teste_y = dataTeste['Casos']

SEED = 5
np.random.seed(SEED)

# Definir o modelo
modelo = DecisionTreeRegressor(random_state=SEED)

# Definir os parâmetros para o GridSearch
param_grid = {
    'max_depth': [None, 5, 10, 15],
    'min_samples_split': [2, 5, 10],
    'min_samples_leaf': [1, 2, 4],
    'max_features': ['sqrt', 'log2', None]
}

# Realizar o GridSearchCV para encontrar os melhores parâmetros
grid_search = GridSearchCV(modelo, param_grid, cv=5,
                           scoring='neg_mean_squared_error')
grid_search.fit(treino_x, treino_y)


# Treinar o modelo com os melhores parâmetros
modelo = grid_search.best_estimator_

print("Treino x e Y", treino_x.head(), treino_y.head())
modelo.fit(treino_x, treino_y)

# Fazer previsões
print("Teste x", teste_x)
previsoes = modelo.predict(teste_x)

# Aplicar transformação para garantir que as previsões sejam não negativas
previsoes = np.maximum(previsoes, 0)

# Calcular o erro médio quadrático (mean squared error) como métrica de avaliação
print("Valores de Y", teste_y)
mse = mean_squared_error(teste_y, previsoes)
print(f"Erro Médio Quadrático: {mse}")
print(previsoes)

# Plotar os valores reais vs. previstos
plt.figure(figsize=(10, 5))
plt.plot(teste_y.values, label='Casos Reais')
plt.plot(previsoes, label='Casos Previstos')
plt.xlabel('Amostras')
plt.ylabel('Número de Casos')
plt.legend()
plt.show()
