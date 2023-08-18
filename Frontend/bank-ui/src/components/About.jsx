import React from 'react'
import Home from './home'
import Login from './Login'
function About()
{
    
  let isLoggedIn = localStorage.getItem("isLoggedIn")
  if(isLoggedIn=="true"){
    return (
    <>
    <div class="container">
    
    <hr class="featurette-divider"/>

<div class="row featurette">
  <div class="col-md-7">
    <br/>
    <br/><br/>
    <h2 class="featurette-heading">Who We <span class="text-muted">Are</span></h2>
    <p class="lead">We are a leading bank in India, with a history of over 100 years of serving our customers with trust, integrity and innovation. We offer a wide range of banking products and services, from savings and current accounts, to loans, cards, insurance and investments. We have a network of over 5000 branches and 15000 ATMs across the country, as well as a robust digital platform that enables you to bank anytime, anywhere.</p>
  </div>
  <div class="col-md-5">
    <img class="featurette-image img-fluid mx-auto" src="https://img.freepik.com/free-vector/men-teamwork-with-briefcase-business-coins_24877-54774.jpg?w=740&t=st=1691660078~exp=1691660678~hmac=69a14dcdedb4634732d9dd9268447a30a66d8699c51deb93ad404d8fcc4c94df" alt="Generic placeholder image"/>
  </div>
</div>

<hr class="featurette-divider" />

<div class="row featurette">
  <div class="col-md-7 order-md-2">
    <br/>
    <br/>
    <br/>
    <h2 class="featurette-heading">What We <span class="text-muted">Do</span></h2>
    <p class="lead">We are committed to providing you with the best banking experience, whether you are an individual, a business or a corporate. We understand your needs and aspirations, and we tailor our solutions to suit them. We also strive to create value for our stakeholders, including our shareholders, employees, regulators and society at large. We are driven by our vision of becoming the most admired bank in India.</p>
  </div>
  <div class="col-md-5 order-md-1">
    <img class="featurette-image img-fluid mx-auto" src="https://img.freepik.com/free-vector/flat-gamer-room-illustration_23-2148955229.jpg?w=740&t=st=1691660721~exp=1691661321~hmac=254ab2959ec976594b262b2e97e4eae8e22fcbf29e99e1fce2cb6f819655afff" alt="Generic placeholder image"/>
  </div>
</div>

<hr class="featurette-divider"/>

<div class="row featurette">
  <div class="col-md-7">
    <br/>
    <br/>
    <br/>
    <h2 class="featurette-heading">How We <span class="text-muted">Care</span></h2>
    <p class="lead">We care about our customers, and we go the extra mile to make them happy. We listen to their feedback and suggestions, and we constantly improve our products and services to meet their expectations. We also care about our employees, and we foster a culture of learning, growth and diversity. We care about our environment, and we adopt sustainable practices to reduce our carbon footprint. We care about our community, and we support various social causes and initiatives to make a positive difference.</p>
  </div>
  <div class="col-md-5">
    <img class="featurette-image img-fluid mx-auto" src="https://img.freepik.com/free-vector/flat-design-young-people-helping-elderly-illustration_23-2150159840.jpg?w=740&t=st=1691660582~exp=1691661182~hmac=2e2b492762f3f2512809a081f33580cfce7f38f557e45432cb0dffcfe7113db2" alt="Generic placeholder image"/>
  </div>
</div>

</div>

    </>
  )}
  else{



       return <Login/>
  }
    
   
}

export default About;