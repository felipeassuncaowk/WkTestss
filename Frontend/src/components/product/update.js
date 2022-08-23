import React, { useState, useEffect } from 'react';
import { Button, Checkbox, Form } from 'semantic-ui-react'
import axios from 'axios';
import {
    useParams
  } from "react-router-dom";

export default function Update() {
    const [id, setID] = useState(null);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [fgActive, setFgActive] = useState(false);


    let paramId = useParams().id;

    const getUrl = `http://localhost:5010/product/${paramId}`
    const putUrl = `http://localhost:5010/product`

    useEffect(() => {
        axios.get(getUrl)
            .then((response) => {
                console.log(response.data)
                setID(response.data.payload.id)
                setName(response.data.payload.name);
                setDescription(response.data.payload.description);
                setFgActive(response.data.payload.fgActive);
            })
    }, []);

    const updateAPIData = () => {
        axios.put(putUrl, {
            id,
            name,
            description,
            fgActive
        }).then(() => {
            window.location = '/product'
        })
    }
    return (
        <div>
            <Form className="create-form">
                <Form.Field>
                    <label>Nome</label>
                    <input placeholder='Npme' value={name} onChange={(e) => setName(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>Descricão</label>
                    <input placeholder='Descricão' value={description} onChange={(e) => setDescription(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <Checkbox label='Produto Disponível para venda?' checked={fgActive} onChange={() => setFgActive(!fgActive)}/>
                </Form.Field>
                <Button type='submit' onClick={updateAPIData}>Update</Button>
            </Form>
        </div>
    )
}
