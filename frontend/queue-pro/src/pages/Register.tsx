import { useState } from 'react';
import { Link } from 'react-router-dom';
import styles from './Login.module.css'; // или путь к вашим стилям

export default function Register() {

  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [name, setName] = useState('');

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    
    // Проверка совпадения паролей
    if (password !== confirmPassword) {
      alert('Пароли не совпадают');
      return;
    }

    // Здесь логика регистрации
    console.log('Registration data:', { name, login, password });
  };

  return (
    <div className="AllPage">
      <div className={styles.top}>
        <div className={styles.orange_thing}>
          <a className={styles.logo} href="/login">
            <img className={styles.logo2} src="logo2.png" alt="Logo" />
            Pro
          </a>
        </div>
      </div>
      <div className={styles.container}>
        <h2 className={styles.enter}>Регистрация</h2>
        <form onSubmit={handleSubmit}>
          <input 
            className={styles.input} 
            type="text" 
            placeholder="ФИО" 
            value={name} 
            onChange={(e) => setName(e.target.value)}
            required 
          />
          <input 
            className={styles.input} 
            type="login" 
            placeholder="Логин" 
            value={login} 
            onChange={(e) => setLogin(e.target.value)}
            required 
          />
          <input 
            className={styles.input} 
            type="password" 
            placeholder="Пароль" 
            value={password} 
            onChange={(e) => setPassword(e.target.value)}
            required 
          />
          <input 
            className={styles.input} 
            type="password" 
            placeholder="Подтвердите пароль" 
            value={confirmPassword} 
            onChange={(e) => setConfirmPassword(e.target.value)}
            required 
          />
          <button className={styles.button} type="submit">Зарегистрироваться</button>
        </form>
        <div className={styles.register}>
          Уже есть учётная запись? 
          <Link to="/login">
            <span>Войти</span>
          </Link>
        </div>
      </div>
    </div>
  );
};
