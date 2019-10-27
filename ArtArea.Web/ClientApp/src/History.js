import { createBrowserHistory } from 'history';

const historyInternal = createBrowserHistory()

export function getHistory()
{
    return historyInternal
}