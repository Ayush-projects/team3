import React from 'react'
import bank from '../assets/bank.svg'


function Nav()
{ 

  let isLoggedIn  = localStorage.getItem("isLoggedIn")
  
  function handleLogout()
  {
    localStorage.removeItem("isLoggedIn")
    localStorage.removeItem("token")
    window.location.reload()
  }



    return <>


    
<nav class="navbar navbar-expand-md bg-dark sticky-top border-bottom" data-bs-theme="dark">
  <div class="container">
  <a href="/" class="navbar-brand d-flex align-items-center">
     
        <strong>X Bank</strong>
      </a>
    <a class="navbar-brand d-md-none" href="#">
      <svg class="bi" width="24" height="24"></svg>
     
    </a>
    <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvas" aria-controls="#offcanvas" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="offcanvas offcanvas-end" tabindex="-1" id="#offcanvas" aria-labelledby="#offcanvasLabel">
      <div class="offcanvas-header">
        <h5 class="offcanvas-title" id="#offcanvasLabel">Bank</h5>
        <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
      </div>
      <div class="offcanvas-body">
        <ul class="navbar-nav flex-grow-1 justify-content-between">
          <li class="nav-item"><a class="nav-link" href="#">
            <svg class="bi" width="24" height="24"></svg>
          </a></li>
          <li class="nav-item"><a class="nav-link" href="/">Home</a></li>
          <li class="nav-item"><a class="nav-link" href="/dashboard">Dashboard</a></li>
          <li class="nav-item"><a class="nav-link" href="/about">About</a></li>
          <li class="nav-item"><a class="nav-link" href="/service">Service</a></li>
          <li class="nav-item"><a class="nav-link" href="/contact">Contact</a></li>
         {isLoggedIn=="true" ? (
          
        <li class="nav-item"><a href="#" onClick={handleLogout} class="btn btn-primary">Logout</a></li>
         ) : 
          (
     <li class="nav-item"><a href="/login" class="btn btn-primary">Login</a></li>
         )}
        
          
        
        </ul>
      </div>
    </div>
  </div>
</nav>
    
    
    
    </>
}



export default Nav;