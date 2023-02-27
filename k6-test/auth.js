import encoding from 'k6/encoding';
import http from 'k6/http';
import { check } from 'k6';

const username = 'username12345';
const email = 'username12345@example.com';
const password = 'Password12345';

const BASE_URL = "http://localhost:5000";

export function setup() {
    // register a new user and authenticate via a Bearer token.
    const res = http.post(`${BASE_URL}/user/register/`, {
      email: email,
      username: username,
      password: password,
    });
  
  
    check(res, { 'created user': (r) => r.status === 201 });
  
  
    const loginRes = http.post(`${BASE_URL}/auth/token/login/`, {
  
      username: username,
  
      password: password,
  
    });
  
  
    const authToken = loginRes.json('access');
  
    check(authToken, { 'logged in successfully': () => authToken !== '' });
  
  
    return authToken;
  
  }
  
  
  export default (authToken) => {
  
    const requestConfigWithTag = (tag) => ({
  
      headers: {
  
        Authorization: `Bearer ${authToken}`,
  
      },
  
      tags: Object.assign(
  
        {},
  
        {
  
          name: 'PrivateCrocs',
  
        },
  
        tag
  
      ),
  
    });
}
