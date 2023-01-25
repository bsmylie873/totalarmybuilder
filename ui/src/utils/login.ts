import jwtDecode from "jwt-decode";

const isTokenExpired = (token: any) => {
    if (!token || !token.accessToken || !token.refreshToken) return true;
    const accessJwt = jwtDecode(token.accessToken) as any;
    const currentTime = new Date().getTime() / 1000;

    if (currentTime < accessJwt.exp) return false;

    const refreshJwt = jwtDecode(token.refreshToken) as any;

    if (currentTime < refreshJwt.exp) return false;

    return true;
};

const getEmail = (accessToken: any) => {
    if (!accessToken) return false;

    const {claims: {email}} = jwtDecode(accessToken) as any;

    return email;
};

const getAccountUsernameDisplay = (accessToken: any): string => {
    if (!accessToken) return "";

    const {claims: {username}} = jwtDecode(accessToken) as any;

    return `${username}`;
};

const getAccountId = (accessToken: string) => {
    if (!accessToken) return false;

    const {sub} = jwtDecode(accessToken) as any;

    console.log(accessToken)

    return sub;
};

const getAccountIdRefresh = (refreshToken: string) => {
    if (!refreshToken) return false;

    const {sub} = jwtDecode(refreshToken) as any;

    if (sub == undefined) return false;

    return sub;
};

const LoginUtils = {
    isTokenExpired,
    getEmail,
    getAccountUsernameDisplay,
    getAccountId,
    getAccountIdRefresh
};

export default LoginUtils;