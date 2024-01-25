
# Mediator

Este projeto tem a ideia de aprender similaridades sobre o padrão Mediator, implementando um código no padrão DDD. 


## Docum

#### Retorna todos os Pacientes

```http
  GET /api/Pacientes
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `Guid` | **Obrigatório**. A chave da sua API |

#### Retorna um  Paciente

```http
  GET /api/Pacientes/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. O ID do item que você quer |

#### Deleta Paciente

```http
  DELETE /api/Pacientes/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. Pesquisa o ID e exclui quando o encontra |

#### Update Paciente

```http
  UPDATE /api/Pacientes/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. Pesquisa ID na lista e atualiza o item. |


#### Create Paciente

```http
  CREATE /api/Pacientes
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. Cria um paciente. |