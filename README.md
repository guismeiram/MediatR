

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
| `id`      | `Guid` | 
**Obrigatório**. O ID do item que você quer |

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
| `Nome`      | `string` | **Obrigatório**. Atualiza o Nome na lista. |
| `Idade`      | `string` | **Obrigatório**. Atualiza a Idade na lista. |
| `Rg`      | `string` | **Obrigatório**. Atualiza o Rg na lista.  |
| `Sexo`      | `Enum` | **Obrigatório**. Atualiza a Sexo na lista. |


#### Create Paciente

```http
  CREATE /api/Pacientes
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. Cria um paciente. |
| `Nome`      | `string` | **Obrigatório**. Cria o Nome na lista. |
| `Idade`      | `string` | **Obrigatório**. Cria a Idade na lista. |
| `Rg`      | `string` | **Obrigatório**. Cria o Rg na lista. |
| `Sexo`      | `Enum` | **Obrigatório**. Atualiza a Sexo na lista. |
