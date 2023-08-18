import React from 'react'
import Home from './home'
import Login from './Login'

function Service()
{

    
  let isLoggedIn = localStorage.getItem("isLoggedIn")
  if(isLoggedIn=="true"){
    return (<>
   <>
    <div class="container">
    
    <hr class="featurette-divider"/>

<div class="row featurette">
  <div class="col-md-7">
    <br/>
    <br/><br/>
    <h2 class="featurette-heading">Savings <span class="text-muted">Account</span></h2>
    <p class="lead">A savings account is a basic banking service that allows you to deposit and withdraw money, earn interest and enjoy other benefits. You can choose from various types of savings accounts, such as regular, premium, senior citizen, women, children and more. You can also access your account online, through mobile banking or phone banking. A savings account is ideal for your everyday banking needs.</p>
  </div>
  <div class="col-md-5">
    <img class="featurette-image img-fluid mx-auto" src="https://img.freepik.com/free-vector/salary-payment-concept-illustration-with-man-get-income-his-job_513217-187.jpg?w=740&t=st=1691661207~exp=1691661807~hmac=5392096765d799f86a038ef8d3e869b14ff5703f985c1c8477281c4dfe1bb261" alt="Generic placeholder image"/>
  </div>
</div>

<hr class="featurette-divider" />

<div class="row featurette">
  <div class="col-md-7 order-md-2">
    <br/>
    <br/>
    <br/>
    <h2 class="featurette-heading">Personal  <span class="text-muted">Loan</span></h2>
    <p class="lead">A personal loan is a flexible and convenient way to finance your personal needs, such as education, travel, wedding, medical expenses and more. You can borrow up to Rs. 20 lakhs, with attractive interest rates and repayment options. You can also avail of pre-approved offers, balance transfer and top-up facilities. A personal loan is easy to apply for, with minimal documentation and quick approval</p>
  </div>
  <div class="col-md-5 order-md-1">
    <img class="featurette-image img-fluid mx-auto" src="https://img.freepik.com/free-vector/premium-cash-reward-bonus-work-done-best-employee-rewarding-promotion-order-efficiency-stimulation-boss-subordinate-cartoon-characters_335657-2984.jpg?w=740&t=st=1691661274~exp=1691661874~hmac=b713dd4e974d950841f317105e64288e69fb24eaea0ceebd310a90b52bed95bd" alt="Generic placeholder image"/>
  </div>
</div>

<hr class="featurette-divider"/>

<div class="row featurette">
  <div class="col-md-7">
    <br/>
    <br/>
    <br/>
    <h2 class="featurette-heading">Credit <span class="text-muted">Card</span></h2>
    <p class="lead">A credit card is a powerful tool that enables you to shop, travel, dine and enjoy life without worrying about cash. You can choose from various types of credit cards, such as rewards, cashback, travel, lifestyle and more. You can also enjoy features such as EMI conversion, fuel surcharge waiver, insurance cover and more. A credit card is secure and convenient to use, with online and offline payment options.</p>
  </div>
  <div class="col-md-5">
    <img class="featurette-image img-fluid mx-auto" src="https://img.freepik.com/free-vector/business-man-with-credit-card_1284-3434.jpg?w=740&t=st=1691661329~exp=1691661929~hmac=9ba3c1a4c461cc814aaca1fb137addba8e32987b10bc114d6312d08d626a2e27" alt="Generic placeholder image"/>
  </div>
</div>

</div>

    </>
    

    </>)}
    else{
      return <Login/>
    }
}

export default Service;