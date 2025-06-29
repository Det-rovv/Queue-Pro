import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Link } from 'react-router-dom';
import styles from "./Login.module.css";

export default function Login() {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    // Простая фейковая авторизация
    if (login && password) {
      localStorage.setItem("token", "fake-token");
      navigate("/");
    }
  };

  return (
    <div className="AllPage">
        <div className={styles.top}>
            
            <div className={styles.orange_thing}>
                <a className={styles.logo} href="/register">
                    <img className={styles.logo2} src="logo2.png"></img> 
                    Pro 
                </a>
            </div>
            
        </div>
        <div className={styles.container}>
            <h2 className={styles.enter}>Вход</h2>
            <form onSubmit={handleSubmit}>
                <input
                className={styles.input}
                type="login"
                placeholder="Логин"
                value={login}
                onChange={(e) => setLogin(e.target.value)}
                />
                <input
                className={styles.input}
                type="password"
                placeholder="Пароль"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                />
                <button className={styles.button} type="submit">Войти</button>
            </form>
            <div className={styles.register}>Нет учётной записи? <Link to="/register"><span>Зарегистрироваться</span></Link> </div>
        </div>
    </div>
  );
}