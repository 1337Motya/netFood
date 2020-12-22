import React from 'react';
import axios from 'axios'

function Login({ setLogged }) {
    const [username, setUsername] = React.useState('');
    const [password, setPassword] = React.useState('');

    const login = (username, password) => {
        var data = {
            username: username,
            password: password
        };
        axios.post('https://localhost:44345/api/Users/Login', data).then((response) => {
            localStorage.setItem('token', response.data.token);
            setLogged(true);
        });

    };

    return (
        <div>
            <div className="login-field">
                <h3>Имя пользователя:</h3>
                <input className="item-input" value={username} onChange={(e) => setUsername(e.target.value)} type="text" />
            </div>
            <div className="login-field">
                <h3>Пароль:</h3>
                <input className="item-input" value={password} onChange={(e) => setPassword(e.target.value)} type="password" />
            </div>
            <div className="button" onClick={() => login(username, password)}>
                Войти
           </div>
        </div>
    );
}

export default Login;