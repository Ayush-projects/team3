import logo from './logo.svg';
import './App.css';
import Home from './components/home.jsx'
import Dashboard from './components/dashboard';
import About from './components/About'
import Service from './components/Service'
import Contact from './components/Contact'
import  Footer  from  './components/Footer';
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import Nav from './components/Nav'
import Login from './components/Login'
import CustomerDashboard from './components/CustomerDashboard'
import Notification  from './components/Notification';
import AddCustomer from './components/AddCustomer';
import AddAccout from './components/AddAccount';

function App() {
  return (
   <>
  <Nav></Nav>
  <BrowserRouter>
  <Notification/>
  <Routes>
      <Route path = "/" element= {<Home/>}/>
      <Route path = "/dashboard" element = {<Dashboard/>}/>
      <Route path = "/about" element = {<About/>}/>
      <Route path="/service" element={<Service/>} />
      <Route path = "/contact" element = {<Contact/>}/>
      <Route path="/login" element= {<Login />} />
      <Route path = "/custDash" element = {<CustomerDashboard/>} />
      <Route path = "/addCust" element = {<AddCustomer/>}/>
      <Route path ="/addAccount" element ={<AddAccout/>}/>
    </Routes>
    </BrowserRouter>
    <Footer></Footer>
    </> 
  );
}

export default App;
