import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Button, Header, List } from 'semantic-ui-react';

function App() {
  const [activites, setActivities] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5000/api/activities')
    .then(response => {
      setActivities(response.data);
    })
  }, [])

  return (
    <div>
      <Header as="h2" icon="users" content="Reactivities"/>
        <List>
          {activites.map((activity: any) =>(
            <List.Item key={activity.id}>{activity.title}</List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
