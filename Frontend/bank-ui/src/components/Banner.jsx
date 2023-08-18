import React from 'react'
import ReactDOM from 'react-dom'
import banner1 from '../assets/banner1.jpg'
import banner2 from '../assets/banner2.jpg'
import banner3 from '../assets/banner3.jpg'



function Banner() {
  return (
    <div id="carouselExampleCaptions" className="carousel slide">
      <div className="carousel-indicators">
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" className="active" aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
      </div>
      <div className="carousel-inner">
        <div className="carousel-item active">
          <img src={banner1} className="d-block w-100" alt="..." />
          <div className="carousel-caption d-none d-md-block">
            <h5>Banking at your Fingertips</h5>
            <p>Fastest Banking transactions in Asia Pacific.</p>
          </div>
        </div>
        <div className="carousel-item">
          <img src={banner2} className="d-block w-100" alt="..." />
          <div className="carousel-caption d-none d-md-block">
            <h5>Banking Beyond Boundaries</h5>
            <p>Global Solutions, Local Trust - Your Passport to Prosperity.</p>
          </div>
        </div>
        <div className="carousel-item">
          <img src={banner3} className="d-block w-100" alt="..." />
          <div className="carousel-caption d-none d-md-block">
            <h5>Invest in Tomorrow, Today</h5>
            <p>Planting Seeds of Wealth for a Flourishing Future.</p>
          </div>
        </div>
      </div>
      <button className="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
        <span className="carousel-control-prev-icon" aria-hidden="true"></span>
        <span className="visually-hidden">Previous</span>
      </button>
      <button className="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
        <span className="carousel-control-next-icon" aria-hidden="true"></span>
        <span className="visually-hidden">Next</span>
      </button>
    </div>
  )
}

export default Banner;