import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.tree import DecisionTreeRegressor
from sklearn.metrics import mean_squared_error
from sklearn.model_selection import GridSearchCV, train_test_split

# Carregar os dados
data = pd.read_csv('dados.csv')  # Certifique-se de que o caminho está correto

x = data[['TempMin', 'TempMax', 'Chuva']]
y = data['Casos']

SEED = 5
np.random.seed(SEED)

# Dividir os dados em treino e teste sem estratificação
treino_x, teste_x, treino_y, teste_y = train_test_split(x, y, test_size=0.20, random_state=SEED)

# Definir o modelo
modelo = DecisionTreeRegressor(random_state=SEED)

# Definir os parâmetros para o GridSearch
param_grid = {
    'max_depth': [None, 10, 20, 30],
    'min_samples_split': [2, 5, 10],
    'min_samples_leaf': [1, 2, 4],
    'max_features': ['sqrt', 'log2', None]
}

# Realizar o GridSearchCV para encontrar os melhores parâmetros
grid_search = GridSearchCV(modelo, param_grid, cv=5, scoring='neg_mean_squared_error')
grid_search.fit(treino_x, treino_y)

# Imprimir os melhores parâmetros encontrados
print("Melhores parâmetros encontrados:", grid_search.best_params_)

# Treinar o modelo com os melhores parâmetros
modelo = grid_search.best_estimator_
modelo.fit(treino_x, treino_y)

# Fazer previsões
previsoes = modelo.predict(teste_x)

# Aplicar transformação para garantir que as previsões sejam não negativas
previsoes = np.maximum(previsoes, 0)

# Calcular o erro médio quadrático (mean squared error) como métrica de avaliação
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
