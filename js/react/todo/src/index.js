import React from 'react';
import ReactDOM from 'react-dom';

const App = () => {
    return (
        <div>
            <AppHeader/>
            <SearchPanel/>
            <TodoList/>
        </div>
    )
}

const AppHeader = () => {
    return (
        <h1>Todo app</h1>
    )
}

const SearchPanel = () => {
    return (
        <input placeholder="search"/>
    )
}

const TodoList = () => {
    return (
        <ul>
            <li>123</li>
            <li>456</li>
            <li>789</li>
        </ul>
    )
}

const el = (
    <App/>
);

ReactDOM.render(el, document.getElementById('root'));

