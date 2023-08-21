import React from 'react'
import '../styles/style.css'
import { useState } from 'react';
import { NotificationManager } from 'react-notifications';
import axios from 'axios'
import Dashboard from './dashboard';



function Login()
{ 

  let [email, setEmail] = useState("");
  let [password, setPassword] = useState("");


  try{

   
   function validateEmail(email) {
    const emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    return emailPattern.test(email);
  }

 
   function submit()
   {
    
      if(email=="" || password=="")
      {
        return NotificationManager.error("Please enter both email and password","Error",4000);
      }

      if(!validateEmail(email))
      {
         return NotificationManager.error("Email is in incorrect format", "Error", 4000);
      }
    
      axios.post('https://localhost:5000/api/Auth',{email, password})
      .then((response) => {

          
        if(response.status==200)
        {
          NotificationManager.success("Login Successful", "Success", 3000);
        
          localStorage.setItem("token", response.data.token)
          localStorage.setItem("isLoggedIn", "true")
           setTimeout(()=>{
             window.location.reload()
           }, 3000)
        }
        else

        {
          NotificationManager.error("Incorrect Credentials", "Error", 4000);
        }





      } ).catch((err)=>{
        NotificationManager.error(err.message, "Error", 4000);
      });
   
  
    
   }
    

   let isLoggedIn = localStorage.getItem("isLoggedIn")
   if(isLoggedIn=="true")
   {
       return <>
       <Dashboard/>
       </>
   }


    return (
        <>
        <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
          class="img-fluid" alt="Sample image" />
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>
       

         

        
          <div class="form-outline mb-4">
            <input type="email" id="form3Example3" class="form-control form-control-lg"
              placeholder="Enter email" value={email} onChange={function(e){setEmail(e.target.value)}}/>
            <label class="form-label" for="form3Example3">Email address</label>
        
          </div>

          <div class="form-outline mb-3">
            <input type="password" id="form3Example4" class="form-control form-control-lg"
              placeholder="Enter password" value={password} onChange={function(e){setPassword(e.target.value)}}/>
            <label class="form-label" for="form3Example4">Password</label>
           
          </div>


          <div class="text-center text-lg-start mt-4 pt-2">
            <button type="button" class="btn btn-primary btn-sm"
              style={{paddingLeft: "2.5rem", "paddingRight": "2.5rem"}} onClick={submit}>Login</button>
            
          </div>

        </form>
      </div>
    </div>
  </div>
 
</section></>
    )

  }catch(err)
  {
      
   // NotificationManager.error(err.message, "Error", 4000);
  }
  
}


export default Login