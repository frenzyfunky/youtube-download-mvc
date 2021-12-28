import axios, { Method } from 'axios'

interface ApiResponse<T> {
    isSuccess: boolean;
    message: string;
    data: T;
}

const getView = async (method: Method, body: {}, path: string): Promise<string> => {
    const response = await axios.request<ApiResponse<string>>({
        method: method,
        url: path,
        data: body,
    });

    return response.data.data;
}

export default getView;