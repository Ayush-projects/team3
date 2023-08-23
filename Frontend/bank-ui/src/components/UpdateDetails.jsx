import React, { useState } from "react";
import '../styles/style.css'
import { NotificationManager } from 'react-notifications';
import updimage from '../assets/uppd.svg';
import axios from 'axios'
import Login from './Login'
import DashboardHeader from "./DashboardHeader";

export default function UpdateDetails()
{

    let isLoggedIn = localStorage.getItem("isLoggedIn")
    let token = localStorage.getItem("token")
    const [formData,setFormData] = useState({
        email:'',
        address: '',
        contactNum: '',
        id  : ''      
    });


    const handleInputChange = (event) =>{
        const {name,value} = event.target;

        setFormData({
            ...formData,
            [name] : value
        })
    }

    const handleSubmit = (event) =>{
   console.log(event.target.value)
   let param = event.target.value
        console.log('in handle submit');
    event.preventDefault();

        let {email,address,contactNum,id} = formData;
   let token = localStorage.getItem("token")
   if(!token)
   {

    NotificationManager.error("Some Error Occured, Please Login", "Error", 4000);
          
           
    setTimeout(()=>{
      window.location.href = "/login"
    }, 4000)

        
   }
        if(param=='upd email')
        {
            console.log('in email');
        axios.put("https://localhost:5000/api/Customer/UpdateCustomerEmail" ,{id,email},{ headers: {
          'Authorization': 'Bearer '+ token
        }})
        .then((response) => {  
          if(response.status==200)
          {
            NotificationManager.success("Updated email id:" + response.data.id, "Success", 4000);
             setTimeout(()=>{
               window.location.reload()
             }, 4000)
          }
          else
          {
            NotificationManager.error(response.data.value, "Error", 4000);
          }
        } ).catch((err)=>{
         console.log(err)
          NotificationManager.error(JSON.stringify(err.response.data.errors), "Error", 4000);
        });
        }
        
        if(param=='upd address')
        {

        axios.put("https://localhost:5000/api/Customer/UpdateCustomerAddress" ,{id,address},{ headers: {
          'Authorization': 'Bearer '+ token
        }})
        .then((response) => {  
          if(response.status==200)
          {
            NotificationManager.success("Updated address:" + response.data.id, "Success", 4000);
             setTimeout(()=>{
               window.location.reload()
             }, 4000)
          }
          else
          {
            NotificationManager.error(response.data.value, "Error", 4000);
          }
        } ).catch((err)=>{
         console.log(err)
          NotificationManager.error(JSON.stringify(err.response.data.errors), "Error", 4000);
        });
        }
        
        if(param=='upd num')
        {

        axios.put("https://localhost:5000/api/Customer/UpdateCustomerContactNo" ,{id,contactNo: contactNum},{ headers: {
          'Authorization': 'Bearer '+ token
        }})
        .then((response) => {  
          if(response.status==200)
          {
            NotificationManager.success("Updated Contact Num:" + response.data.id, "Success", 4000);
             setTimeout(()=>{
               window.location.reload()
             }, 4000)
          }
          else
          {
            NotificationManager.error(response.data.value, "Error", 4000);
          }
        } ).catch((err)=>{
         console.log(err)
          NotificationManager.error(JSON.stringify(err.response.data.errors), "Error", 4000);
        });
        }

    
    
    
    }

    if(isLoggedIn=="true"){


    return (
        <>
        <DashboardHeader></DashboardHeader>
        <div className="addCusContainer">
        <img className = 'addCusImage' src = {updimage} alt = 'sample-image2'/>
        <div class = 'container w-50 formContainer'>
        
    <form>
        <div>
        <div class="col ">
            <label for="ID" class="form-label">Email</label>
            <input type="text" class="form-control "  id="email"
            onChange={handleInputChange}
            name = "email"
            value = {formData.email}
             />
            <label for="id" class="form-label">ID</label>
            <input type="text" class="form-control "  id="ID"
            onChange={handleInputChange}
            name = "id"
            value = {formData.id}
             />
             <div class="d-grid gap-2 col-6 mx-auto incmar">
            <button type="submit" class="btn btn-primary" value='upd email' onClick={handleSubmit}>Update Email</button>
            </div>
        </div>

        <div class="col ">
            <label for="Address" class="form-label">Address</label>
            <input type="text" class="form-control " id="Address" 
            onChange={handleInputChange}
            name = "address"
            value = {formData.address}
            />
            <label for="id" class="form-label">ID</label>
            <input type="text" class="form-control "  id="ID"
            onChange={handleInputChange}
            name = "id"
            value = {formData.id}
             />
            <div class="d-grid gap-2 col-6 mx-auto incmar">
            <button type="submit" class="btn btn-primary" value ='upd address'onClick={handleSubmit}>Update Address</button>
            </div>
        </div>
        </div>
        <div>
        <div class="mb-3 col">
            <label for="contactnum" class="form-label">New Contact Number</label>
            <input type="text" class="form-control " 
            onChange={handleInputChange}
            name = "contactNum"
            value = {formData.contactNum}
            />
            <label for="id" class="form-label">ID</label>
            <input type="text" class="form-control "  id="ID"
            onChange={handleInputChange}
            name = "id"
            value = {formData.id}
             />
             <div class="d-grid gap-2 col-6 mx-auto incmar">
            <button type="submit" class="btn btn-primary" value ='upd num' onClick={handleSubmit}>Update Contact Number</button>
            </div>
            
        </div>

        </div>

 
        
  </form>
        </div>
        </div>
   </>
    );

}else{

return <>
<Login/>
</>


}





}