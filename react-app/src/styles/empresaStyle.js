import styled from 'styled-components';

export const Container = styled.div`
    margin-top: 20px;

    li {
        display:flex;
        justify-content: space-between;
        align-items: center;
        color: #444;

        & + li {
            margin-top: 15px;
        }
    }
`;