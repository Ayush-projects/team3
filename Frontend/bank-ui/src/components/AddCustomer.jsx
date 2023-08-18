import React, { useState } from "react";
import '../styles/style.css'
import { NotificationManager } from 'react-notifications';
import svgImage from '../assets/addcus.svg';
import axios from 'axios'
import Login from './Login'
import DashboardHeader from "./DashboardHeader";
export default function AddCustomer()
{

    let isLoggedIn = localStorage.getItem("isLoggedIn")
    const [formData,setFormData] = useState({
        name : '',
        address : '',
        email : '',
        contactNo : '',
      
    });


    const handleInputChange = (event) =>{
        const {name,value} = event.target;

        setFormData({
            ...formData,
            [name] : value
        })
    }

    const handleSubmit = (event) =>{

    event.preventDefault()

        for(const key in formData)
        {      
            if(formData[key]=='')
            return NotificationManager.error("Please fill the complete form ","Error",4000);
        }

        if(!formData.email.includes('@'))
        return NotificationManager.error("Please put email in correct format","Error",4000);
          let {email, name, address, contactNo} = formData

   let token = localStorage.getItem("token")
   if(!token)
   {

    NotificationManager.error("Some Error Occured, Please Login", "Error", 4000);
          
           
    setTimeout(()=>{
      window.location.href = "/login"
    }, 4000)

        
   }

        axios.post("https://localhost:5000/api/Customer/AddCustomer",{name, email, address, contactNo})
        .then((response) => {
          console.log(response)
            
          if(response.status==200)
          {
            NotificationManager.success("Customer Successfully Added with Id:" + response.data.id, "Success", 4000);
          
           
             setTimeout(()=>{
               window.location.reload()
             }, 4000)
          }
          else
  
          {
          
            NotificationManager.error(response.data.value, "Error", 4000);
          }
  
  
  
  
  
        } ).catch((err)=>{
         
          NotificationManager.error(JSON.stringify(err.response.data.errors), "Error", 4000);
        });
     
        



        
    }

    if(isLoggedIn=="true"){


    return (
        <>
        <DashboardHeader></DashboardHeader>
        <div className="addCusContainer">
        <img className = 'addCusImage' src = {svgImage} alt = 'sample-image2'/>
        <div class = 'container w-50 formContainer'>
        
    <form>
        <div>
        <div class="col ">
            <label for="Name1" class="form-label">Name</label>
            <input type="text" class="form-control "  id="name"
            onChange={handleInputChange}
            name = "name"
            value = {formData.name}
             />
        </div>

        <div class="col w-50">
            <label for="Address" class="form-label">Address</label>
            <input type="text" class="form-control " id="Address" 
            onChange={handleInputChange}
            name = "address"
            value = {formData.address}
            />
        </div>
        </div>
        <div>
        <div class="mb-3 col">
            <label for="email" class="form-label">Email-id</label>
            <input type="email" class="form-control " id="exampleInputEmail1" aria-describedby="emailHelp"
            onChange={handleInputChange}
            name = "email"
            value = {formData.email}
            />
            
        </div>

        <div class="mb-3 col">
            <label for="contactNo" class="form-label">Contact</label>
            <input type="string" class="form-control " id="contactnum"
            onChange={handleInputChange}
            name = "contactNo"
            value = {formData.contactNo}
            />
            
        </div>
        </div>

 
        <div class="d-grid gap-2 col-6 mx-auto">

        <button type="submit" class="btn btn-primary" onClick={handleSubmit}>Add Customer</button>
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