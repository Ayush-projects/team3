import React, { useState } from "react";
import '../styles/style.css'
import { NotificationManager } from 'react-notifications';
import svgImage from '../assets/addcus.svg';
import { useNavigate } from "react-router";
import axios from 'axios'
import Login from './Login'
import DashboardHeader from "./DashboardHeader";
export default function AddAccout()
{

    const [formData,setFormData] = useState({
        id: '',
        accType : '',
        cardNo: '',
        cardName : '',
        balance : '',
        atmPin: ''
            
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
         
            if(formData[key]==='')
            return NotificationManager.error("Please fill the complete form ","Error",4000);
        }

       

        if(formData.balance<1000)
        return NotificationManager.error("Inital balance must be atleast 1000","Error","4000");
       let { id,accType , cardNo, cardName, balance, atmPin} = formData
       console.log(formData)
    let token = localStorage.getItem("token")
        axios.post("https://localhost:5000/api/Account/AddAccount",{ id,accType , cardNo, cardName, balance, atmPin}, {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        })
        .then((response) => {
          console.log(response)
            
          if(response.status==200)
          {
            NotificationManager.success("Account Successfully Added with Account Number:" + response.data.accNum, "Success", 10000);
          
           
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

 
    let isLoggedIn = localStorage.getItem("isLoggedIn")

    if(isLoggedIn=="true"){
    return (
        <>
        <DashboardHeader></DashboardHeader>
        <div className="addCusContainer">
         
        <img className = 'addCusImage' src = {svgImage} alt = 'sample-image2'/>
        <div class = 'container w-50 formContainer'>
        
    <form>
        <div>
        

        <div class="col w-50">
            <label for="text" class="form-label">Account type</label>
            <input type="text" class="form-control " id="accountType" 
            onChange={handleInputChange}
            name = "accType"
            value = {formData.accType}
            />
        </div>
        </div>
        <div>
        <div class="mb-3 col">
            <label for="text" class="form-label">Balance</label>
            <input type="text" class="form-control " placeholder="Enter Initial Balance" id="balance" 
            onChange={handleInputChange}
            name = "balance"
            value = {formData.balance}
            />
            
        </div>

        <div class="mb-3 col">
            <label for="text" class="form-label">Card Number</label>
            <input type="text" class="form-control " id="pinnum"
            onChange={handleInputChange}
            name = "cardNo"
            value = {formData.cardNo}
            />
            
        </div>

        <div class="mb-3 col">
            <label for="contact" class="form-label">Card Name</label>
            <input type="text" class="form-control " id="pinnum"
            onChange={handleInputChange}
            name = "cardName"
            value = {formData.cardName}
            />
            
        </div>

        <div class="mb-3 col">
            <label for="atmPin" class="form-label">Pin</label>
            <input type="password" class="form-control " id="pinnum"
            onChange={handleInputChange}
            name = "atmPin"
            value = {formData.atmPin}
            />
            
        </div>

        <div class="mb-3 col">
            <label for="contact" class="form-label">Id</label>
            <input type="text" class="form-control " id="pinnum"
            onChange={handleInputChange}
            name = "id"
            value = {formData.id}
            />
            
        </div>
        </div>

 
        <div class="d-grid gap-2 col-6 mx-auto">

        <button type="submit" class="btn btn-primary" onClick={handleSubmit}>Add Account</button>
        </div>
  </form>
        </div>
        </div>
        </>

    );}
    else{
        return <><Login/></>
    }
}