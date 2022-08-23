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


    let paramId = useParams().id;

    const getUrl = `http://localhost:5010/category/${paramId}`
    const putUrl = `http://localhost:5010/category`

    useEffect(() => {
        axios.get(getUrl)
            .then((response) => {
                console.log(response.data)
                setID(response.data.payload.id)
                setName(response.data.payload.name);
                setDescription(response.data.payload.description);
            })
    }, []);

    const updateAPIData = () => {
        axios.put(putUrl, {
            id,
            name,
            description
        }).then(() => {
            window.location = '/category'
        })
    }
    return (
        <div>
            <Form className="create-form">
                <Form.Field>
                    <label>Nome</label>
                    <input placeholder='Nome' value={name} onChange={(e) => setName(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>Descricão</label>
                    <input placeholder='Descricão' value={description} onChange={(e) => setDescription(e.target.value)}/>
                </Form.Field>
                <Button type='submit' onClick={updateAPIData}>Update</Button>
            </Form>
        </div>
    )
}
