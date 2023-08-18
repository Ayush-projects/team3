import React, { useState } from "react";
import '../styles/style.css'
import { NotificationManager } from 'react-notifications';
import svgImage from '../assets/addcus.svg';
import { useNavigate } from "react-router";
import Login from "./Login";
import DashboardHeader from "./DashboardHeader";
import axios from 'axios'


export default function CashWithdraw()
{

    let isLoggedIn  = localStorage.getItem("isLoggedIn");

    const [formData,setFormData] = useState({
        accnum : '',
        amount: ''
    });

    const navigate = useNavigate();


    const handleInputChange = (event) =>{
        const {name,value} = event.target;

        setFormData({
            ...formData,
            [name] : value
        })
    }

    const handleSubmit = (event) =>{

        event.preventDefault();

        for(const key in formData)
        {      
            console.log(key,formData[key]);
            if(formData[key]=='')
            return NotificationManager.error("Please fill the complete form ","Error",4000);
        }

        if(formData.accnum.length<16)
        return NotificationManager.error("Account number must be of 16 numerical digits","Error",4000);

       
        let {accnum,amount} = formData;
        
    
        axios.post("https://localhost:5000/api/Transaction/AddTransaction",{ accNum1:accnum,transType:"Withdraw",accNum2:accnum,amount:amount})
        .then((response) => {
          console.log(response)

          if(response.status==200)
          {
            NotificationManager.success("Amount successfully withdrawn", "Success", 10000);
                     
             setTimeout(()=>{
               window.location.reload()
             }, 6000)
          }
          else
  
          {
          
            NotificationManager.error(response.data.value, "Error", 30000);
          }
  
  
  
  
  
        } ).catch((err)=>{
            console.log(err)
         if(err.response.data.value)
         {
            NotificationManager.error(err.response.data.value, "Error", 30000);
         }
         else
          NotificationManager.error(JSON.stringify(err.response.data.errors), "Error", 30000);
        });


        
        
    }


if(isLoggedIn){
    return (
        <> <DashboardHeader/> 
        <div className="addCusContainer">
            
            <div class = 'container w-50 withdContainer'>
                <h3> Cash Withdrawal</h3>
    <form>
        <div>
        <div class="col ">
            <label for="Name1" class="form-label">Account number</label>
            <input type="text" class="form-control "  id="accnum"
            onChange={handleInputChange}
            name = "accnum"
            value = {formData.accnum}
             />
        </div>

        <div class="col w-50">
            <label for="Address" class="form-label">Amount</label>
            <input type="text" class="form-control " id="accountType" 
            onChange={handleInputChange}
            name = "amount"
            value = {formData.amount}
            />
        </div>
        </div>
      
 
        <div class="d-grid gap-2 col-6 mx-auto btnpp">

        <button type="submit" class="btn btn-primary" onClick={handleSubmit}>Submit</button>
        </div>
  </form>
        </div>
        </div>
        </>

    );
}
else
return(<Login/>);
}