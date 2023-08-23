import React from 'react';
import bank from '../assets/bank.svg';
import 'bootstrap/dist/css/bootstrap.min.css'; // Make sure to import Bootstrap CSS

function Nav() {
  let isLoggedIn = localStorage.getItem("isLoggedIn");

  function handleLogout() {
    localStorage.removeItem("isLoggedIn");
    localStorage.removeItem("token");
    window.location.reload();
  }

  return (
    <>
      <nav className="navbar navbar-expand-md bg-dark sticky-top border-bottom" data-bs-theme="dark">
        <div className="container">
          <a href="/" className="navbar-brand d-flex align-items-center">
            <strong>X Bank</strong>
          </a>
          <button className="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvas" aria-controls="offcanvas" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="offcanvas offcanvas-end" tabIndex="-1" id="offcanvas" aria-labelledby="offcanvasLabel">
            <div className="offcanvas-header">
              <h5 className="offcanvas-title" id="offcanvasLabel">Bank</h5>
              <button type="button" className="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
            </div>
            <div className="offcanvas-body">
              <ul className="navbar-nav flex-grow-1 justify-content-between">
                <li className="nav-item"><a className="nav-link" href="#">Link 1</a></li>
                <li className="nav-item"><a className="nav-link" href="/">Home</a></li>
                <li className="nav-item"><a className="nav-link" href="/dashboard">Dashboard</a></li>
                <li className="nav-item"><a className="nav-link" href="/about">About</a></li>
                <li className="nav-item"><a className="nav-link" href="/service">Service</a></li>
                <li className="nav-item"><a className="nav-link" href="/contact">Contact</a></li>
                {isLoggedIn === "true" ? (
                  <li className="nav-item"><a href="#" onClick={handleLogout} className="btn btn-primary">Logout</a></li>
                ) : (
                  <li className="nav-item"><a href="/login" className="btn btn-primary">Login</a></li>
                )}
              </ul>
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}

export default Nav;
