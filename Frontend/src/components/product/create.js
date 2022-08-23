import React, { useState } from 'react';
import { Button, Checkbox, Form } from 'semantic-ui-react'
import axios from 'axios';

export default function Create() {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [fgActive, setFgActive] = useState(false);
    console.log(fgActive)
    const postData = () => {
        axios.post(`http://localhost:5010/product`, {
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
                    <input placeholder='Nome' minLength={3} onChange={(e) => setName(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>Descrição</label>
                    <input placeholder='Descrição' minLength={3} onChange={(e) => setDescription(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <Checkbox label='Produto disponível para vendas' onChange={(e) => setFgActive(!fgActive)}/>
                </Form.Field>
                <Button onClick={postData} type='submit'>Submit</Button>
            </Form>
        </div>
    )
}
