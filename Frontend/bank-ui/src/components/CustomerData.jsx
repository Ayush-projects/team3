import React, { Component } from 'react';
import '../styles/customerData.css'
import CustomerDetailsRow from './CustomerDetailsRow';
import {useState} from 'react';
import axios from 'axios';
import Login from './Login'
import DashboardHeader from './DashboardHeader';
import CustomerTransactions from './CustomerTransactions';
export default function CustomerData({name, accountNumber, balance, type, cardNumber}){

        var [isShown, setIsShown] = useState(false);

        var handleClick = event => {
            setIsShown(current => !current);            
        };
        
        const formatter = new Intl.NumberFormat("en-US", {
          style: "currency",
          currency: "INR",
        });

		
        //const { accountNumber, customerId, accountBalance } = this.state.customerData;
    let isLoggedIn = localStorage.getItem("isLoggedIn")
	if(isLoggedIn=="true"){
        return (
			<>
			
    <div class="container d-flex justify-content-center mt-5">

	<div class="card">
		
		<div class="top-container">
			
			{/* <img src="https://i.imgur.com/G1pXs7D.jpg" class="img-fluid profile-image" width="70"/> */}
			
			<div class="ml-3">
				<h5 class="name">{name}</h5>
				<p class="acc-number">Acc Number: {accountNumber}</p>
			</div>
		</div>


		<div class="middle-container d-flex justify-content-between align-items-center mt-3 p-2">
				<div class="dollar-div px-3">
					
					<div class="round-div">
                        <span class="rupees"> &#8377;</span>
                        </div>

				</div>
				<div class="d-flex flex-column text-right mr-2">
					<span class="current-balance">Current Balance</span>
					<span class="amount"><span class="dollar-sign"></span>{formatter.format(balance)}</span>
				</div>

		</div>

		<div class="recent-border mt-4">
			<span class="recent-orders" onClick = {handleClick}>Recent Transactions</span>
            
            {isShown ? <CustomerTransactions accountNumber={accountNumber}/> : null}
		</div>
		<div class="account-type-border pt-2">
			<span class="account-type">Account Type: {type}</span>
		</div>
		<div class="card-number-border pt-2">
			<span class="card-number">Card Number: {cardNumber}</span>
		</div>
		
	</div>
	
    </div>
	</>
    );
		}else
		{
			return <><Login></Login></>
		}
    
 }
