import { useContext, useState } from 'react'

import { useNavigate } from 'react-router-dom'
import { UserContext } from '../../hooks/UserContext'

import Form from '../../components/Form/Form'
import Input from '../../components/Inputs/Input/Input'
import Button from '../../components/Button/Button'
import LinkForm from '../../components/Links/LinkForm/LinkForm'



const Login = () => {
    const { login } = useContext(UserContext)
    const [error, setError] = useState('')
    const navigate = useNavigate()

    const onSubmit = async (e) => {
        e.preventDefault()

        const email = e.target.email.value.trim()
        const password = e.target.password.value.trim()

        if (email.length <= 0 || password.length <= 0) {
            setError('Todos os campos precisam estar preenchidos.')
        }
        else {
            try {
                await login(email, password);
                navigate('/')
            } catch (error) {
                console.log(error)
            }
        }
    }

    return (
        <Form headerText='Login' onSubmit={onSubmit}>
            <Input type="email" name="email" placeholder="Email" className="input" />
            <Input type="password" name="password" placeholder="Senha" className="password" />
            <Button text="Login" />
            <LinkForm message='Não possui uma conta? ' link='/cadastro' textLink='Cadastre-se' />
        </Form>
    )
}

export default Login