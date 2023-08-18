import React from 'react';

import '../styles/styles.css';
// import NotificationIcon from '../assets/icons/notification.svg';
import SettingsIcon from '../assets/icons/settings.svg';
import { useNavigate } from 'react-router-dom';

function DashboardHeader () {
    
    const  navigate = useNavigate();

    function handleClick(event)
    {   
        console.log("Click here");
        //navigate(name);
    }

    
    return(
        <div className='dashbord-header-container'>
             
                <a href='/addCust'>  <button className='dashbord-header-btn' >Add new Customer</button>  </a>
                <a href = '/custDash'> <button className='dashbord-header-btn' >View Customer Data</button> </a>
                <a href = '/addAccount'><button className='dashbord-header-btn' >Add Account</button></a>
                <a href = '/addAccount'><button className='dashbord-header-btn dropdown-toggle' 
                type ='button' data-bs-toggle ='dropdown'>Add Transaction</button>
                
                <ul class ="dropdown-menu">
                    <li><a class ="dropdown-item" href ='/cwith'>Withdrawal</a></li>
                    <li><a class ="dropdown-item" href = '/cdep'>Deposit</a></li>
                    <li><a class ="dropdown-item" href = '/fundtrans'>Transfer</a></li>
                </ul>
                
                
                </a>
                  
            

           
        </div>
    )
}

export default DashboardHeader;