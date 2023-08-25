import React, { Component, useState } from 'react';
import { NotificationManager } from 'react-notifications';
import axios from 'axios';
import CustomerData from './CustomerData';
import '../styles/searchBar.css';
import DashboardHeader from './DashboardHeader';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
//import { faSearch} from '@fortawesome/free-solid-svg-icons'
import { faXmark, faSearch } from '@fortawesome/free-solid-svg-icons'

function SearchBar() {
    let [accountNumber, setAccountNumber] = useState();
    let [show, setShow] = useState(false);
    let [account, setAccount] = useState([]);
    function handleClick() {
      setAccountNumber(null);
    }
    
    function submit()
    {
      console.log(accountNumber);
       if(accountNumber == "")
       {
         return NotificationManager.error("Please enter account number","Error",4000);
       }
       let token = localStorage.getItem("token");
       console.log(token);
      //  let token = localStorage.getItem("token")
        
      //   axios.post("https://localhost:5000/api/Transaction/AddTransaction",{ accNum1:accnum,transType:"Withdraw",accNum2:accnum,amount:amount},{
      //       headers: {
      //           'Authorization': 'Bearer ' + token
      //       }
      //   })
        axios.get("https://localhost:5000/api/Account/GetAccountByAccNo?accNo="+ `${accountNumber}`, {
          headers: {
            'Authorization': 'Bearer ' + token
        }
        })
        .then((response) => {
            console.log(response);
          
            if(response.status==200)
            {
              let account1 = response.data;
              console.log(account1);

              setAccount(account1);
              console.log(account);
              setShow(true);
              setAccountNumber("");
            //   <CustomerData name= {account.name} accountNumber={account.accountNumber} type= {account.type} cardNumber={account.cardNumber}  balance= {account.balance} />
             } 
            else {
              NotificationManager.error("Enter valid Account Number", "Error", 4000);
            }
        })
    }
    
        return (
       
            <>
            
            <div class="container">

            <div class="row height d-flex justify-content-center align-items-center">

              <div class="col-md-6">
              

                <div class="form">
                
                <FontAwesomeIcon icon={faSearch} class = "fa fa-search"/>

                  <input type="text" class="form-control form-input" value={accountNumber} onChange={function(e){setAccountNumber(e.target.value)}} placeholder="Enter Account Number..."/>
                  <span class="left-pan" onClick={()=>{setAccountNumber("")}}><FontAwesomeIcon icon={faXmark} class = "fa fa-arrow"/></span>
                 
                  
                  {/* <span class="left-pan"><button type="submit" class = "btn btn-primary">{`&#xf105`}</button></span> */}
                </div>
                <button class ="submit-btn" onClick= {submit}> SEARCH</button>
              </div>
              
            </div>
            {show? (<CustomerData name= {account.name} accountNumber={account.accNum} type= {account.accType} cardNumber={account.cardNo}  balance= {account.balance} />): <div></div>}
            
          </div>
        
            </>






            
          
            
    );
    }
export default SearchBar;
