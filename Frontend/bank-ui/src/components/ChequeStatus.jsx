import React, { useState } from "react";
import '../styles/style.css'
import { NotificationManager } from 'react-notifications';
import updimage from '../assets/uppd.svg';
import axios from 'axios'
import Login from './Login'
import DashboardHeader from "./DashboardHeader";


function ChequeStatus()
{
   
    let isLoggedIn = localStorage.getItem("isLoggedIn")
    let token = localStorage.getItem("token")
    const [formData,setFormData] = useState({
     accNum: ""
    });


    const handleInputChange = (event) =>{
        const {name,value} = event.target;

        setFormData({
            ...formData,
            [name] : value
        })
    }

    const handleSubmit = (event) =>{

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
          
        axios.get("https://localhost:5000/api/Cheque/GetChequeDetailsByAccNo?AccNum="+ accNum ,{ headers: {
          'Authorization': 'Bearer '+ token
        }})
        .then((response) => {  
            console.log(response)
          if(response.status==200)
          {
              if(response.data.length==0)
              {
                NotificationManager.success("No Active Cheques", "Success", 20000);

              }
            for(let i=0; i<response.data.length; i++)
            {
              NotificationManager.success("Amount: "+response.data[i].amount + "       Status: "  + response.data[i].status, "Cheque No: "+response.data[i].chequeNo, 20000);

            }
             setTimeout(()=>{
               window.location.reload()
             }, 20000)
          }
          else
          {
          
            NotificationManager.error(response.data.value, "Error", 4000);
          }
        } ).catch((err)=>{
         console.log(err.response)
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
            <button type="submit" class="btn btn-primary" value='enable' onClick={handleSubmit}>Check Status</button>
        
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

export default ChequeStatus