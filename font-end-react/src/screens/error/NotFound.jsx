import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./NotFound.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/404");
export default function NotFound() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/404">


    <header className="navbar navbar-expand-lg">
  <div className="container">
    <a className="navbar-brand text-white" href="/">
      <img src="/assets/static/img/hutech-logo.png" alt="HUTECH Logo" className="me-2" />{"\n                Hệ thống Sinh viên HUTECH\n            "}</a>
    <div className="ms-auto">
      <button id="toggleTheme" className="btn btn-outline-light"><i className="bi bi-moon-stars"></i></button>
    </div>
  </div>
    </header>


    <div className="container-error">
  <div className="error-content">
    <i className="bi bi-exclamation-circle error-icon"></i>
    <h1 className="error-code">{"404"}</h1>
    <p className="error-message">{"Rất tiếc, trang bạn đang tìm kiếm không tồn tại hoặc đã bị di chuyển."}</p>
    <a href="/" className="btn btn-primary"><i className="bi bi-house"></i>{" Về trang chủ"}</a>
  </div>
    </div>


    <footer className="footer">
  <div className="container">
    <p>{"Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025"}</p>
  </div>
    </footer>



  </div>;
}
