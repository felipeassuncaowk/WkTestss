import './App.css';
import Home from './components/home/home';
import CategoryCreate from './components/category/create';
import CategoryRead from './components/category/read';
import CategoryUpdate from './components/category/update';
import ProductCreate from './components/product/create';
import ProductRead from './components/product/read';
import ProductUpdate from './components/product/update';
import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";

import { Header, Image, Button, Divider } from 'semantic-ui-react'
function App() {
  return (
    <div className='main'>
      <div className='head'>
        <a href="/"><Image src='/logo192.png' size='small' /></a>
        <Header size='medium'>WkCommerce</Header>
        <Divider />
        <p><a href="/category"><Button>Categoria</Button></a></p>
        <p><a href="/product"><Button>Produtos</Button></a></p>
      </div>
      <div className='content'>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/category" element={<CategoryRead />} />
            <Route path="/category/edit/:id" element={<CategoryUpdate />} />
            <Route path="/category/create" element={<CategoryCreate />} />
            <Route path="/product" element={<ProductRead />} />
            <Route path="/product/edit/:id" element={<ProductUpdate />} />
            <Route path="/product/create" element={<ProductCreate />} />
          </Routes>
        </BrowserRouter>
      </div>
    </div>
  );
}

export default App;
