import React, { useState } from "react";
import '../styles/style.css'
import { NotificationManager } from 'react-notifications';
import updimage from '../assets/uppd.svg';
import axios from 'axios'
import Login from './Login'
import DashboardHeader from "./DashboardHeader";


function Enable()
{
   
    let isLoggedIn = localStorage.getItem("isLoggedIn")
    let token = localStorage.getItem("token")
    const [formData,setFormData] = useState({
     accNum: "", accStatus: ""     
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

      
   let token = localStorage.getItem("token")
   if(!token)
   {

    NotificationManager.error("Some Error Occured, Please Login", "Error", 4000);
          
           
    setTimeout(()=>{
      window.location.href = "/login"
    }, 4000)

      
   }

   let {accNum} = formData
        if(true)
        {
          console.log("AYush")
        axios.put("https://localhost:5000/api/Account/EnableDisableStatus" ,{accNum,accStatus: event.target.value},{ headers: {
          'Authorization': 'Bearer '+ token
        }})
        .then((response) => {  
            console.log(response)
          if(response.status==200)
          {
            NotificationManager.success(response.data.value, "Success", 20000);
             setTimeout(()=>{
               window.location.reload()
             }, 20000)
          }
          else
          {
            NotificationManager.error(response.data.message, "Error", 4000);
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
            <label for="ID" class="form-label">Account Number</label>
            <input type="text" class="form-control "  id="email"
            onChange={handleInputChange}
            name = "accNum"
            value = {formData.accNum}
             />
           
             <div class="d-grid gap-2 col-6 mx-auto incmar">
            <button type="submit" class="btn btn-primary" value='enable' onClick={handleSubmit}>Enable</button>
            <button type="submit" class="btn btn-primary" value='Disable' onClick={handleSubmit}>Disable</button>
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

export default Enable