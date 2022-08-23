import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Table, Button } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

export default function Read() {
    
    const [APIData, setAPIData] = useState([]);
    const getUrl = `http://localhost:5010/product`
    const newUrl = `/product/create`

    useEffect(() => {
        axios.get(getUrl)
            .then((response) => {
                console.log(response.data)
                setAPIData(response.data.payload.items);
            })
    }, []);

    const getData = () => {
        axios.get(getUrl)
            .then((response) => {
                setAPIData(response.data.payload.items);
            })
    }

    const onDelete = (id) => {
        axios.delete(`${getUrl}/${id}`)
        .then(() => {
            getData();
        })
    }

    return (
        <div>

            <Link to={newUrl}><Button>Novo</Button></Link>

            <Table singleLine>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.HeaderCell>Nome</Table.HeaderCell>
                        <Table.HeaderCell>Descrição</Table.HeaderCell>
                        <Table.HeaderCell>Ativo</Table.HeaderCell>
                        <Table.HeaderCell>Ações</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>

                <Table.Body>
                    {APIData.map((data) => {

                        var editUri = '/product/edit/' + data.id;

                        return (
                            <Table.Row key={data.id}>
                                <Table.Cell>{data.id}</Table.Cell>
                                <Table.Cell>{data.name}</Table.Cell>
                                <Table.Cell>{data.description}</Table.Cell>
                                <Table.Cell>{data.fgActive ? 'Sim' : 'Não'}</Table.Cell>
                                <Table.Cell>
                                    <Link to={editUri}>
                                        <Button>Editar</Button>
                                    </Link>
                                    <Button onClick={() => onDelete(data.id)}>Excluir</Button>
                                </Table.Cell>
                            </Table.Row>
                        )
                    })}
                </Table.Body>
            </Table>
        </div>
    )
}
