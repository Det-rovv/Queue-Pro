import { useState } from 'react';
import { Link } from 'react-router-dom';
import styles from './Main.module.css'; // или путь к вашим стилям

export default function Main() {
  return (
    <div className="AllPage">
      <div className={styles.top}>
        <div className={styles.orange_thing}>
          <a className={styles.logo} href="/main">
            <img className={styles.logo2} src="logo2.png" alt="Logo" />
            Pro
          </a>
        </div>
      </div>
      <main className={styles.main_content}>
            
            <div className={styles.card}>
                <h2>Выберите пару</h2>
                <div className={styles.className_selector}>
                    <div className={`${styles.className_card} ${styles.active}`}>
                        <div className={styles.className_name}>Математический анализ</div>
                        <div className={styles.className_info}>Понедельник, 8:30 • Ауд. 301</div>
                    </div>
                    <div className={styles.className_card}>
                        <div className={styles.className_name}>Программирование</div>
                        <div className={styles.className_info}>Вторник, 10:15 • Ауд. 205</div>
                    </div>
                    <div className={styles.className_card}>
                        <div className={styles.className_name}>Физика</div>
                        <div className={styles.className_info}>Среда, 14:00 • Ауд. 108</div>
                    </div>
                </div>
            </div>

            <div className={`${styles.card} ${styles.queue_container}`}>
                <div className={styles.queue_header}>
                    <h2 className={styles.queue_title}>Очередь на сдачу работ</h2>
                    <div className={`${styles.queue_status} ${styles.status_open}`}>
                        🟢 Запись открыта
                    </div>
                </div>

                <div className={styles.queue_list}>
                    <div className={`${styles.queue_item} ${styles.first}`}>
                        <div className={styles.queue_position}>1</div>
                        <div className={styles.student_info}>
                            <div className={styles.student_name}>Анна Смирнова</div>
                            <div className={styles.join_time}>Записалась в 07:35</div>
                        </div>
                        <div className={styles.queue_actions}>
                            <button className={`${styles.btn} ${styles.btn_secondary}`}>💬 Обменяться</button>
                        </div>
                    </div>

                    <div className={styles.queue_item}>
                        <div className={styles.queue_position}>2</div>
                        <div className={styles.student_info}>
                            <div className={styles.student_name}>Михаил Козлов</div>
                            <div className={styles.join_time}>Записался в 08:12</div>
                        </div>
                        <div className={styles.queue_actions}>
                            <button className={`${styles.btn} ${styles.btn_secondary}`}>💬 Обменяться</button>
                        </div>
                    </div>

                    <div className={`${styles.queue_item} ${styles.current_user}`}>
                        <div className={styles.queue_position}>3</div>
                        <div className={styles.student_info}>
                            <div className={styles.student_name}>Иван Петров (Вы)</div>
                            <div className={styles.join_time}>Записались в 08:45</div>
                        </div>
                        <div className={styles.queue_actions}>
                            <button className={`${styles.btn} ${styles.btn_danger}`}>❌ Выйти</button>
                        </div>
                    </div>

                    <div className={styles.queue_item}>
                        <div className={styles.queue_position}>4</div>
                        <div className={styles.student_info}>
                            <div className={styles.student_name}>Елена Волкова</div>
                            <div className={styles.join_time}>Записалась в 09:23</div>
                        </div>
                        <div className={styles.queue_actions}>
                            <button className={`${styles.btn} ${styles.btn_secondary}`}>💬 Обменяться</button>
                        </div>
                    </div>
                </div>

                <div className={styles.admin_controls}>
                    <h3 className={styles.admin_title}>🛡️ Управление старосты</h3>
                    <div>
                        <button className={`${styles.btn} ${styles.btn_secondary}`}>👥 Переместить студента</button>
                        <button className={`${styles.btn} ${styles.btn_secondary}`}>❌ Удалить из очереди</button>
                        <button className={`${styles.btn} ${styles.btn_secondary}`}>🔒 Закрыть запись</button>
                        <button className={`${styles.btn} ${styles.btn_secondary}`}>📊 Статистика</button>
                    </div>
                </div>
            </div>
        </main>
    </div>
  );
};
