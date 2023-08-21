import React, { Component, useState } from 'react';
import { NotificationManager } from 'react-notifications';
import axios from 'axios';
import CustomerData from './CustomerData';
function SearchBar() {
    let [accountNumber, setAccountNumber] = useState();
    let [show, setShow] = useState(false);
    let [account, setAccount] = useState([]);
    
    const onClick = () => setShow(true);
    function submit()
    {
     
       if(accountNumber == null)
       {
         return NotificationManager.error("Please enter account number","Error",4000);
       }
 
        axios.get("https://localhost:5000/api/Account/GetAccountByAccNo", {accountNumber})
        .then((response) => {

          
            if(response.status==200)
            {
              let account = response.data;
              console.log(account);
              
              setAccount({account})
              setShow(true);
            //   <CustomerData name= {account.name} accountNumber={account.accountNumber} type= {account.type} cardNumber={account.cardNumber}  balance= {account.balance} />
             } 
            else {
              NotificationManager.error("Enter valid Account Number", "Error", 4000);
            }
        })
    }
        return (
            <div className="container">

            <div className="row height d-flex justify-content-center align-items-center">

              <div className="col-md-6">

                <div className="form">
                  {/* <i className="fa fa-search"></i> */}
                  {/* <input type="input" className="form-control form-input" placeholder="Search by account number..."/>
                  <button> Search </button> */}

                  <div class="form-outline mb-3">
            <input type="input" id="form3Example4" class="form-control form-control-lg"
              placeholder="Enter Account Number" value={accountNumber} onChange={function(e){setAccountNumber(e.target.value)}}/>
            <label class="form-label" for="form3Example4"></label>
           
          </div>


          <div class="text-center text-lg-start mt-4 pt-2">
            <button type="button" class="btn btn-primary btn-sm"
              style={{paddingLeft: "2.5rem", "paddingRight": "2.5rem"}} onClick={submit}>Search</button>
            
          </div>
                  {/* <span className="left-pan"> <FaSearch /> </span>  */}
                
            </div>
            {show==true? (<CustomerData name= {account.name} accountNumber={account.accountNumber} type= {account.type} cardNumber={account.cardNumber}  balance= {account.balance} />): <div></div>};
            
                
              </div>
              
            </div>
            
          </div>
            
    );
    }
export default SearchBar;