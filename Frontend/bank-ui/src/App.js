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
import CashDeposit from './components/CashDeposit';
import CashWithdraw from './components/CashWithdraw';
import FundTransfer from './components/FundTransfer';
import PinChange from './components/PinChange';
import CurrencyConverter from './components/CurrencyConverter';
import UpdateDetails from './components/UpdateDetails';

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
      <Route path = "/cdep" element = {<CashDeposit/>}/>
      <Route path = "/cwith" element = {<CashWithdraw/>}/>
      <Route path = "/fundtrans" element = {<FundTransfer/>}/>
      <Route path = "/pinChange" element = {<PinChange/>}/>
      <Route path="/currConversion" element={<CurrencyConverter/>} />
      <Route path="/upDe" element={<UpdateDetails/>} />

    </Routes>
    </BrowserRouter>
    <Footer></Footer>
    </> 
  );
}

export default App;
