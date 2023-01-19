import { Account } from "../types/account";
import {FetchUtils} from "../utils/";

const createAccount = async (newAccount: Account) => {
    const {username, email, password} = newAccount;
    return await FetchUtils.fetchInstance("api/accounts", {
        method: "POST",
        body: JSON.stringify({
            username,
            email,
            password
        }),
    });
};

const updateAccount = async (updateAccount: Account) => {
    const {id, username, email, password} = updateAccount;
    return await FetchUtils.fetchInstance(`api/accounts/${id}`, {
        method: "PATCH",
        body: JSON.stringify({
            username,
            email,
            password
        }),
    });
};

const deleteAccount = async (accountId: string) => {
    return await FetchUtils.fetchInstance(`api/accounts/${accountId}`, {
        method: "DELETE",
    });
};

const getAccount = async (accountId: string) => {
    return await FetchUtils.fetchInstance(`api/accounts/${accountId}`, {
        method: "GET",
    });
};

const getAccountCompositions = async (accountId: string) => {
    return await FetchUtils.fetchInstance(`api/accounts/${accountId}/compositions`, {
        method: "GET",
    });
};

export default {
    createAccount,
    updateAccount,
    deleteAccount,
    getAccount,
    getAccountCompositions
};